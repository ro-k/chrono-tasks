using System.Net;
using System.Text.Json;
using FluentAssertions;
using Lib.Exceptions;
using Lib.Middleware;
using Microsoft.AspNetCore.Http;
using Moq;

namespace UnitTest.Middleware
{
    public class ExceptionHandlerMiddlewareTests
    {
        private readonly Mock<RequestDelegate> _nextMock;
        private readonly ExceptionHandlerMiddleware _middleware;

        public ExceptionHandlerMiddlewareTests()
        {
            _nextMock = new Mock<RequestDelegate>();
            _middleware = new ExceptionHandlerMiddleware(_nextMock.Object);
        }

        [Theory]
        [InlineData(typeof(UserNotFoundException), HttpStatusCode.NotFound)]
        [InlineData(typeof(ConcurrencyStampMismatchException), HttpStatusCode.Conflict)]
        [InlineData(typeof(InvalidLoginException), HttpStatusCode.Unauthorized)]
        [InlineData(typeof(BadRequestException), HttpStatusCode.BadRequest, "Bad request message")]
        [InlineData(typeof(Exception), HttpStatusCode.InternalServerError)]
        public async Task InvokeAsync_ShouldHandleExceptionAndReturnCorrectStatusCode(Type exceptionType, HttpStatusCode expectedStatusCode, string message = "")
        {
            // Given
            var context = new DefaultHttpContext { Response = { Body = new MemoryStream() } };
            var exception = string.IsNullOrEmpty(message) ? (Exception)Activator.CreateInstance(exceptionType)! : (Exception)Activator.CreateInstance(exceptionType, message)!;

            _nextMock.Setup(n => n.Invoke(It.IsAny<HttpContext>())).ThrowsAsync(exception);

            // When
            await _middleware.InvokeAsync(context);

            // Then
            context.Response.StatusCode.Should().Be((int)expectedStatusCode);
            context.Response.ContentType.Should().Be("application/problem+json");

            // Reset the stream position to the beginning before reading
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            
            var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
            var jsonDocument = JsonDocument.Parse(responseBody);

            if(!string.IsNullOrEmpty(message)) jsonDocument.RootElement.GetProperty("Detail").GetString().Should().Be(message);
            jsonDocument.RootElement.GetProperty("StatusCode").GetInt32().Should().Be((int)expectedStatusCode);
        }

        [Fact]
        public async Task InvokeAsync_ShouldInvokeNext_WhenNoExceptionIsThrown()
        {
            // Given
            var context = new DefaultHttpContext();

            _nextMock.Setup(n => n.Invoke(It.IsAny<HttpContext>())).Returns(Task.CompletedTask);

            // When
            await _middleware.InvokeAsync(context);

            // Then
            _nextMock.Verify(n => n.Invoke(context), Times.Once);
            context.Response.StatusCode.Should().Be((int)HttpStatusCode.OK); // no status code change when no exception is thrown
        }
    }

    public static class HttpContextExtensions
    {
        public static async Task<string> ReadAsStringAsync(this HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(response.Body);
            return await reader.ReadToEndAsync();
        }
    }
}
