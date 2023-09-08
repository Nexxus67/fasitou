using fasito.Models;
using System.Threading.Tasks;
using System;
using fasito;
using System.Net.Mail;
using System.Net;
using fasito.Interfaces; 

namespace fasito.Services
{
    public class MyService : IMyService
    {
        public string GetData()
        {
            return "Data from MyService";
        }
    }
}
