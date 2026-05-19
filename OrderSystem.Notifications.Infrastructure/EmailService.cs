
using System;
using System.Diagnostics;
using OrderSystem.Notifications.Application;

namespace OrderSystem.Notifications.Infrastructure
{
    public class EmailService : INotificationService
    {
        public void Send(string to, string message)
        {
            Debug.WriteLine($"Email to {to}: {message}");
        }
    }
}
