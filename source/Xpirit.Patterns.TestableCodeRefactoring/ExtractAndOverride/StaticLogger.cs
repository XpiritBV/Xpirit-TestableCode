using System;
using System.Configuration;
using System.IO;

namespace Xpirit.Patterns.TestableCodeRefactoring.ExtractAndOverride
{
    /// <summary>
    /// Static logger class, exists only for demonstration purposes.
    /// The idea is that calls to this class should be prevented in unit tests
    /// since a logging component could access external components such as the 
    /// file system, a database or the EventLog.
    /// </summary>
    public static class StaticLogger
    {
        public static async void Write(string message)
        {
            using (StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings["Logger.FilePath"]))
            {
                await writer.WriteLineAsync($"{DateTime.UtcNow.ToLongDateString()} - {message}");
            }
        }
    }
}
