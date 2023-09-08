using fasito.Models;
using System.Threading.Tasks;
using System;
using fasito;
using System.Net.Mail;
using System.Net;

namespace fasito.Services
{
    public class ErrorHandlingService
    {
        public void LogError(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }

    }
}
