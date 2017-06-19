using System;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework.Users
{
    public class NotFoundUser : User
    {
        public NotFoundUser() : base (string.Empty, string.Empty, DateTime.MinValue)
        {
            Id = Guid.Empty;
        }
    }
}
