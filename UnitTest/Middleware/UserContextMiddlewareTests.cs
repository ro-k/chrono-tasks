using Lib.Middleware;
using Lib.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;

namespace UnitTest.Middleware
{
    public class UserContextMiddlewareTests
    {
        private readonly Mock<IUserContext> _userContextMock;
        private readonly Mock<RequestDelegate> _nextMock;
        private readonly UserContextMiddleware _middleware;

        public UserContextMiddlewareTests()
        {
            _userContextMock = new Mock<IUserContext>();
            _nextMock = new Mock<RequestDelegate>();
            _middleware = new UserContextMiddleware(_nextMock.Object);
        }

        [Fact]
        public async Task InvokeAsync_ShouldSetUserContextUserId_WhenUserIsAuthenticated()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var user = new ClaimsPrincipal(identity);
            var context = new DefaultHttpContext { User = user };

            // Act
            await _middleware.InvokeAsync(context, _userContextMock.Object);

            // Assert
            _userContextMock.VerifySet(uc => uc.UserId = Guid.Parse(userId), Times.Once);
            _nextMock.Verify(next => next(context), Times.Once);
        }

        [Fact]
        public async Task InvokeAsync_ShouldNotSetUserContextUserId_WhenUserIsNotAuthenticated()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var identity = new ClaimsIdentity(); // Not authenticated
            var user = new ClaimsPrincipal(identity);
            context.User = user;

            // Act
            await _middleware.InvokeAsync(context, _userContextMock.Object);

            // Assert
            _userContextMock.VerifySet(uc => uc.UserId = It.IsAny<Guid>(), Times.Never);
            _nextMock.Verify(next => next(context), Times.Once);
        }

        [Fact]
        public async Task InvokeAsync_ShouldNotSetUserContextUserId_WhenNameIdentifierClaimIsMissing()
        {
            // Arrange
            var identity = new ClaimsIdentity(new List<Claim>(), "TestAuthType");
            var user = new ClaimsPrincipal(identity);
            var context = new DefaultHttpContext { User = user };

            // Act
            await _middleware.InvokeAsync(context, _userContextMock.Object);

            // Assert
            _userContextMock.VerifySet(uc => uc.UserId = It.IsAny<Guid>(), Times.Never);
            _nextMock.Verify(next => next(context), Times.Once);
        }

        [Fact]
        public async Task InvokeAsync_ShouldNotSetUserContextUserId_WhenNameIdentifierIsInvalidGuid()
        {
            // Arrange
            var invalidUserId = "invalid-guid";
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, invalidUserId)
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var user = new ClaimsPrincipal(identity);
            var context = new DefaultHttpContext { User = user };

            // Act
            await _middleware.InvokeAsync(context, _userContextMock.Object);

            // Assert
            _userContextMock.VerifySet(uc => uc.UserId = It.IsAny<Guid>(), Times.Never);
            _nextMock.Verify(next => next(context), Times.Once);
        }
    }
}
