using System;
using Moq;
using Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework;
using Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework.Users;

namespace Xpirit.Patterns.TestableCodeRefactoring.UnitTests.UsingMockFramework
{
    public static class UserRepositoryMockFactory
    {
        public static IUserRepository CreateWithKnownUser()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(mock => mock.IsKnownUser(It.IsAny<string>()))
                .Returns(true);
            userRepositoryMock.Setup(mock => mock.Get(It.IsAny<string>()))
                .Returns(GetUser);

            return userRepositoryMock.Object;
        }

        public static IUserRepository CreateWithUnknownUser()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(mock => mock.IsKnownUser(It.IsAny<string>())).Returns(false);
            userRepositoryMock.Setup(mock => mock.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateTime>()))
                .Returns(GetNewUser);

            return userRepositoryMock.Object;
        }

        public static Mock<IUserRepository> CreateMockWithUnknownUser()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(mock => mock.IsKnownUser(It.IsAny<string>())).Returns(false);
            userRepositoryMock.Setup(mock => mock.Add(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<DateTime>()))
                .Returns(GetNewUser);

            return userRepositoryMock;
        }

        private static NewUser GetNewUser()
        {
            return new NewUser(
                name: It.IsAny<string>(),
                email: It.IsAny<string>(),
                dateOfBirth: It.IsAny<DateTime>());
        }

        private static User GetUser()
        {
            return new User(
                name: It.IsAny<string>(),
                email: It.IsAny<string>(),
                dateOfBirth: It.IsAny<DateTime>());
        }
    }
}

