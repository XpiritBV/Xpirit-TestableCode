using System;
using System.Configuration;
using System.IO;

namespace Xpirit.Patterns.TestableCodeRefactoring.UsingInterfaces
{
    /// <summary>
    /// Logger class which implements the ILogger interface.
    /// </summary>
    public class Logger : ILogger
    {
        public async void Write(string message)
        {
            using (StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings["Logger.FilePath"]))
            {
                await writer.WriteLineAsync($"{DateTime.UtcNow.ToLongDateString()} - {message}");
            }
        }
    }
}
