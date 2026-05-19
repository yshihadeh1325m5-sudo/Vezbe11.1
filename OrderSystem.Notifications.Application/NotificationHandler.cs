using OrderSystem.Shared.Application;
using OrderSystem.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Notifications.Application
{
    public class NotificationHandler
    {
        public NotificationHandler(IEventBus eventBus, INotificationService notificationService) 
        {
            eventBus.Subscribe<OrderCreatedEvent>(e =>
            {
                notificationService.Send(e.Custumer, $"Order Created. Total: {e.Total}");

            });
        }
    }
}
