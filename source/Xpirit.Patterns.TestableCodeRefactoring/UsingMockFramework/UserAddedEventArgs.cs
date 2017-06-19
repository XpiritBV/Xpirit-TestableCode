using System;
using Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework.Users;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingMockFramework
{
    public class UserAddedEventArgs : EventArgs
    {
        public User User { get; set; }
    }
}
