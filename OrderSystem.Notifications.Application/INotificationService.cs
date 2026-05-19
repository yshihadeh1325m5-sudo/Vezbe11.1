
namespace OrderSystem.Notifications.Application
{
    public interface INotificationService
    {
        void Send(string to, string message);
    }
}
