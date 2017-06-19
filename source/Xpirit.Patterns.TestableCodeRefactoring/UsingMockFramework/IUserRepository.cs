using System;
using Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework.Users;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework
{
    public interface IUserRepository
    {
        event EventHandler<UserAddedEventArgs> UserAdded;

        User Get(string email);

        NewUser Add(
            string name,
            string email,
            DateTime dateOfBirth);

        bool IsKnownUser(string email);
    }
}