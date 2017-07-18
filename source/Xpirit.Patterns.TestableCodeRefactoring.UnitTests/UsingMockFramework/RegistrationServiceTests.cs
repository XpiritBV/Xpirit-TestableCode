using System;
using FluentAssertions;
using Moq;
using Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework;
using Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework.Users;
using NUnit.Framework;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingMockFramework
{
    [TestFixture]
    public class RegistrationServiceTests
    {
        [Test]
        public void RegisterUser_WithKnownUser_ReturnsUser()
        {
            // Arrange
            IUserRepository userRepository = UserRepositoryMockFactory.CreateWithKnownUser();
            var registrationService = GetRegistrationService(userRepository);

            // Act
            var result = registrationService.RegisterUser(
                name: It.IsAny<string>(),
                email: It.IsAny<string>(),
                dateOfBirth: It.IsAny<DateTime>());

            // Assert
            result.Should().BeOfType<User>();
        }

        [Test]
        public void RegisterUser_WithUnknownUser_ReturnsNewUser()
        {
            // Arrange
            IUserRepository userRepository = UserRepositoryMockFactory.CreateWithUnknownUser();
            var registrationService = GetRegistrationService(userRepository);

            // Act
            var result = registrationService.RegisterUser(
                name: It.IsAny<string>(),
                email: It.IsAny<string>(),
                dateOfBirth: It.IsAny<DateTime>());

            // Assert
            result.Should().BeOfType<NewUser>();
        }

        [Test]
        public void RegisterUser_WithUnknownUser_AddGetsCalledOnce()
        {
            // Arrange
            Mock<IUserRepository> userRepositoryMock = UserRepositoryMockFactory.CreateMockWithUnknownUser();
            var registrationService = GetRegistrationService(userRepositoryMock.Object);

            // Act
            var result = registrationService.RegisterUser(
                name: It.IsAny<string>(),
                email: It.IsAny<string>(),
                dateOfBirth: It.IsAny<DateTime>());

            // Assert
            userRepositoryMock.Verify(mock => mock.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>()), Times.Once);
        }

        private static RegistrationService GetRegistrationService(IUserRepository userRepository)
        {
            return new RegistrationService(userRepository);
        }
    }
}
