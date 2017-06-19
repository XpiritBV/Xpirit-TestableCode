using System;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework.Users
{
    public class User
    {
        public User(
            string name,
            string email,
            DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
