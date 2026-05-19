using System.Windows;
using OrderSystem.Orders;
using OrderSystem.Persistence.Infrastructure;
using OrderSystem.Notifications.Infrastructure;
using OrderSystem.Shared.Infrastructure;
using OrderSystem.Pricing;
using OrderSystem.Notifications.Application;

namespace OrderSystem.UI
{
    public partial class MainWindow : Window
    {
        private readonly OrderViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            var repo = new JsonOrderRepository();
            var email = new EmailService();
            var time = new SystemDateTimeProvider();
            var id = new GuidGenerator();
            var pricing = new PricingService();
            var eventBus = new InMemoryEventBus();

            var queryService = new OrderQueryService(repo);
            var commandService = new OrderCommandService(repo, time, id, pricing, eventBus);

            var handler = new NotificationHandler(eventBus, email);

            _viewModel = new OrderViewModel(queryService, commandService);

            lstOrders.ItemsSource = _viewModel.Orders;
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CreateOrder(txtCustomer.Text);

            lstOrders.ItemsSource = _viewModel.Orders;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddItem(
                txtProduct.Text,
                txtPrice.Text,
                txtQty.Text);
        }
    }
}