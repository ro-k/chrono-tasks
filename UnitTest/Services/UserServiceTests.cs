using FluentAssertions;
using Lib.DataAccess;
using Lib.DTOs;
using Lib.Exceptions;
using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
// ReSharper disable StringLiteralTypo

namespace UnitTest.Services
{
    public class UserServiceTests
    {
        private readonly Mock<ISignInManagerWrapper> _signInManagerMock;
        private readonly Mock<IUserManagerWrapper> _userManagerMock;
        private readonly Mock<IUserDataAccess> _userDataAccessMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly Mock<IUserContext> _userContextMock;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _signInManagerMock = new Mock<ISignInManagerWrapper>();
            _userManagerMock = new Mock<IUserManagerWrapper>();
            _userDataAccessMock = new Mock<IUserDataAccess>();
            _tokenServiceMock = new Mock<ITokenService>();
            _userContextMock = new Mock<IUserContext>();
            _userService = new UserService(
                _signInManagerMock.Object,
                _userManagerMock.Object,
                _userDataAccessMock.Object,
                _tokenServiceMock.Object,
                _userContextMock.Object);
        }

        [Fact]
        public async Task Login_ShouldReturnToken_WhenLoginIsSuccessful()
        {
            // Given
            var loginDto = new LoginDto
            {
                Username = "testuser",
                Password = "testpassword"
            };
            var user = new User { Username = loginDto.Username };
            var roles = new List<string> { "UserRole" };
            var token = "generated_jwt_token";

            _signInManagerMock.Setup(sm => sm.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false))
                .ReturnsAsync(SignInResult.Success);

            _userDataAccessMock.Setup(uda => uda.FindByUserNameOrThrowAsync(It.Is<User>(u => u.Username == loginDto.Username), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _userDataAccessMock.Setup(uda => uda.GetRolesAsync(It.Is<User>(u => u.Username == loginDto.Username), It.IsAny<CancellationToken>()))
                .ReturnsAsync(roles);

            _tokenServiceMock.Setup(ts => ts.GenerateJwtToken(It.Is<User>(u => u.Username == loginDto.Username), It.Is<List<string>>(r => r.SequenceEqual(roles))))
                .Returns(token);

            // When
            var result = await _userService.Login(loginDto);

            // Then
            result.Should().Be(token);
        }

        [Fact]
        public async Task Login_ShouldThrowInvalidLoginException_WhenLoginFails()
        {
            // Given
            var loginDto = new LoginDto
            {
                Username = "testuser",
                Password = "wrongpassword"
            };

            _signInManagerMock.Setup(sm => sm.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false))
                .ReturnsAsync(SignInResult.Failed);

            // When
            Func<Task> act = async () => await _userService.Login(loginDto);

            // Then
            await act.Should().ThrowAsync<InvalidLoginException>();
        }

        [Fact]
        public async Task Logout_ShouldCallSignOutAsync()
        {
            // When
            await _userService.Logout();

            // Then
            _signInManagerMock.Verify(sm => sm.SignOutAsync(), Times.Once);
        }

        [Fact]
        public async Task Register_ShouldReturnToken_WhenRegistrationIsSuccessful()
        {
            // Given
            var registerDto = new RegisterDto
            {
                Username = "newuser",
                Email = "newuser@example.com",
                FirstName = "New",
                LastName = "User",
                Password = "newpassword"
            };
            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };
            var roles = new List<string> { "DefaultRole" };
            var token = "generated_jwt_token";

            _userManagerMock.Setup(um => um.CreateAsync(It.Is<User>(u => u.Username == registerDto.Username), registerDto.Password))
                .ReturnsAsync(IdentityResult.Success);

            _userManagerMock.Setup(um => um.AddToRoleAsync(It.Is<User>(u => u.Username == registerDto.Username), "DefaultRole"))
                .ReturnsAsync(IdentityResult.Success);

            _signInManagerMock.Setup(sm => sm.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), false, false))
                .ReturnsAsync(SignInResult.Success);

            _userDataAccessMock.Setup(uda => uda.FindByUserNameOrThrowAsync(It.Is<User>(u => u.Username == registerDto.Username), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            _userDataAccessMock.Setup(uda => uda.GetRolesAsync(It.Is<User>(u => u.Username == registerDto.Username), It.IsAny<CancellationToken>()))
                .ReturnsAsync(roles);

            _tokenServiceMock.Setup(ts => ts.GenerateJwtToken(It.Is<User>(u => u.Username == registerDto.Username), It.Is<List<string>>(r => r.SequenceEqual(roles))))
                .Returns(token);

            // When
            var result = await _userService.Register(registerDto);

            // Then
            result.Should().Be(token);
        }

        [Fact]
        public async Task Register_ShouldThrowBadRequestException_WhenRegistrationFails()
        {
            // Given
            var registerDto = new RegisterDto
            {
                Username = "newuser",
                Email = "newuser@example.com",
                FirstName = "New",
                LastName = "User",
                Password = "newpassword"
            };
            var identityErrors = new[] { new IdentityError { Description = "Registration failed" } };
            var identityResult = IdentityResult.Failed(identityErrors);

            _userManagerMock.Setup(um => um.CreateAsync(It.Is<User>(u => u.Username == registerDto.Username), registerDto.Password))
                .ReturnsAsync(identityResult);

            // When
            Func<Task> act = async () => await _userService.Register(registerDto);

            // Then
            await act.Should().ThrowAsync<BadRequestException>().WithMessage("Registration failed");
        }

        [Fact]
        public async Task GetUser_ShouldReturnUserDto_WhenUserExists()
        {
            // Given
            var userId = Guid.NewGuid();
            var user = new User
            {
                UserId = userId,
                Username = "existinguser",
                Email = "existinguser@example.com",
                FirstName = "Existing",
                LastName = "User"
            };

            _userContextMock.Setup(uc => uc.UserId).Returns(userId);
            _userDataAccessMock.Setup(uda => uda.FindByIdAsync(userId.ToString(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);

            // When
            var result = await _userService.GetUser();

            // Then
            result.Should().BeEquivalentTo(UserDto.FromUser(user));
        }
    }
}
