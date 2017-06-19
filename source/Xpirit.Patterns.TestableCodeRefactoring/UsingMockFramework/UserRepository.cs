using System;
using System.Collections.Generic;
using Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework.Users;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework
{
    /// <summary>
    /// Assume this repository communicates to another system we have no control over, such as a database which contains all the users.
    /// </summary>
    public class UserRepository : IUserRepository
    {

        private readonly Dictionary<string, User> _userDictionary;

        public UserRepository()
        {
            _userDictionary = CreateUserDictionary();
        }

        #region PersonAdded event

        public event EventHandler<UserAddedEventArgs> UserAdded;

        protected virtual void OnUserAdded(UserAddedEventArgs e)
        {
            UserAdded?.Invoke(this, e);
        }

        #endregion

        public User Get(string email)
        {
            User foundUser;
            if (_userDictionary.TryGetValue(email, out foundUser))
            {
                return foundUser;
            }

            return new NotFoundUser();
        }

        public NewUser Add(
            string name,
            string email,
            DateTime dateOfBirth)
        {
            var newUser = new NewUser(
                name,
                email,
                dateOfBirth)
            { Id = Guid.NewGuid() };

            _userDictionary.Add(newUser.Email, newUser);
            var userAddedEventArgs = new UserAddedEventArgs {User = newUser};
            OnUserAdded(userAddedEventArgs);

            return newUser;
        }

        public bool IsKnownUser(string email)
        {
            User knownUser;

            return _userDictionary.TryGetValue(email, out knownUser);
        }

        private static Dictionary<string, User> CreateUserDictionary()
        {
            var graceHopper = new User(
                "Grace Hopper",
                "grace@hopper.org",
                new DateTime(1906, 12, 9))
            {
                Id = Guid.NewGuid()
            };
            var alanKay = new User(
                "Alan Kay",
                "alan@kay.org",
                new DateTime(1940, 5, 17))
            {
                Id = Guid.NewGuid()
            };

            var adaLovelace = new User(
                "Ada Lovelace",
                "ada@lovelace.org",
                new DateTime(1815, 12, 10))
            {
                Id = Guid.NewGuid()
            };
        
            return new Dictionary<string, User>
            {
                { graceHopper.Name, graceHopper },
                { alanKay.Name, alanKay },
                { adaLovelace.Name, adaLovelace }
            };
        }
    }
}
