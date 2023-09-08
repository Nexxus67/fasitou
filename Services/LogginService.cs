using fasito.Models;
using System.Threading.Tasks;
using System;
using fasito;
using System.Net.Mail;
using System.Net;
using fasito.Interfaces; 

namespace fasito.Services
{
    public interface ILogger
    {
        void LogInformation(string message);
        void LogError(Exception ex);
        // ... add other log levels/methods as needed
    }

    public class FileLogger : ILogger
    {
        private string _logPath;

        public FileLogger(string logPath)
        {
            _logPath = logPath;
        }

        public void LogInformation(string message)
        {
            WriteToFile($"INFO: {DateTime.Now} - {message}");
        }

        public void LogError(Exception ex)
        {
            WriteToFile($"ERROR: {DateTime.Now} - {ex.Message} - {ex.StackTrace}");
        }

        private void WriteToFile(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(_logPath, true))
            {
                writer.WriteLine(logMessage);
                writer.Close();
            }
        }
    }
}
