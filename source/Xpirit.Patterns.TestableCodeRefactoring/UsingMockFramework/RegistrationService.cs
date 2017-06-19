using System;
using Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework.Users;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework
{
    public class RegistrationService
    {
        private readonly IUserRepository _userRepository;

        public RegistrationService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User RegisterUser(
            string name,
            string email,
            DateTime dateOfBirth)
        {

            if (_userRepository.IsKnownUser(email))
            {
                return _userRepository.Get(email);
            }

            return _userRepository.Add(name, email, dateOfBirth);
        }
    }
}
