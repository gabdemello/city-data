﻿namespace CityDataAPI.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = "admin@citydataAPI.com";
        private string _mailFrom = "noreply@citydataAPI.com";

        public void Send(string subject, string message)
        {   
            // send mail => output to console window
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, " +
                $"with {nameof(LocalMailService)}.");

            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
