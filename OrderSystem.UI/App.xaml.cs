
using Microsoft.Extensions.DependencyInjection;
using OrderSystem.Notifications.Application;
using OrderSystem.Notifications.Infrastructure;
using OrderSystem.Orders;
using OrderSystem.Persistence.Infrastructure;
using OrderSystem.Pricing;
using OrderSystem.Shared.Application;
using OrderSystem.Shared.Infrastructure;
using System;
using System.Windows;

namespace OrderSystem.UI
{
    
    public partial class App : Application {
        private ServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();
            ConfigureService(services);
            _serviceProvider = services.BuildServiceProvider();
            _serviceProvider.GetRequiredService<NotificationHandler>();
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
        private void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<MainWindow>();

            services.AddTransient<OrderCommandService>();
            services.AddTransient<OrderQueryService>();
            services.AddTransient<PricingService>();

            services.AddTransient<IOrderRepository, JsonOrderRepository>();
            services.AddTransient<INotificationService, EmailService>();
            services.AddTransient<IDateTimeProvider, SystemDateTimeProvider>();
            services.AddTransient<IIdGenerator, GuidGenerator>();

            services.AddSingleton<IEventBus, InMemoryEventBus>();
            services.AddTransient<NotificationHandler>();
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _serviceProvider?.Dispose();
            base.OnExit(e);
           
        }
    
    }
}
