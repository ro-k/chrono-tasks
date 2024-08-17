using FluentAssertions;
using Lib.Middleware;
using Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTest.Middleware
{
    public class TokenRefreshMiddlewareTests
    {
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly Mock<RequestDelegate> _nextMock;
        private readonly TokenRefreshMiddleware _middleware;

        public TokenRefreshMiddlewareTests()
        {
            _tokenServiceMock = new Mock<ITokenService>();
            Mock<IServiceScopeFactory> serviceScopeFactoryMock = new();
            Mock<IServiceScope> serviceScopeMock = new();
            Mock<IServiceProvider> serviceProviderMock = new();
            _nextMock = new Mock<RequestDelegate>();

            serviceScopeFactoryMock.Setup(f => f.CreateScope()).Returns(serviceScopeMock.Object);
            serviceScopeMock.Setup(s => s.ServiceProvider).Returns(serviceProviderMock.Object);
            serviceProviderMock.Setup(p => p.GetService(typeof(ITokenService))).Returns(_tokenServiceMock.Object);

            _middleware = new TokenRefreshMiddleware(serviceScopeFactoryMock.Object, _nextMock.Object);
        }

        [Fact]
        public async Task InvokeAsync_ShouldAddNewTokenHeader_WhenTokenNeedsRefresh()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers.Authorization = "Bearer old-token";

            _tokenServiceMock.Setup(ts => ts.TryRefreshToken("old-token"))
                .ReturnsAsync((true, "new-token"));

            // Act
            await _middleware.InvokeAsync(context);

            // Assert
            context.Response.Headers.Should().ContainKey("new-token");
            context.Response.Headers["new-token"].Should().BeEquivalentTo("new-token");
            _nextMock.Verify(next => next(context), Times.Once);
        }

        [Fact]
        public async Task InvokeAsync_ShouldNotAddNewTokenHeader_WhenTokenDoesNotNeedRefresh()
        {
            // Arrange
            var context = new DefaultHttpContext();
            context.Request.Headers.Authorization = "Bearer old-token";

            _tokenServiceMock.Setup(ts => ts.TryRefreshToken("old-token"))
                .ReturnsAsync((false, null!));

            // Act
            await _middleware.InvokeAsync(context);

            // Assert
            context.Response.Headers.Should().NotContainKey("new-token");
            _nextMock.Verify(next => next(context), Times.Once);
        }

        [Fact]
        public async Task InvokeAsync_ShouldNotCheckTokenService_WhenAuthorizationHeaderIsMissing()
        {
            // Arrange
            var context = new DefaultHttpContext();

            // Act
            await _middleware.InvokeAsync(context);

            // Assert
            _tokenServiceMock.Verify(ts => ts.TryRefreshToken(It.IsAny<string>()), Times.Never);
            context.Response.Headers.Should().NotContainKey("new-token");
            _nextMock.Verify(next => next(context), Times.Once);
        }
    }
}
