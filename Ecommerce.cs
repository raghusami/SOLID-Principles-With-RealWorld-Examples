
namespace SOLIDPrinciple
{

    // -------------------- SRP: Separate Responsibilities -------------------- //

    // Models
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = "Test@Gmail.com";
        public string Mobile { get; set; } = "8807319489";
    }

    // Service following SRP

    public class OrderService
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly INotificationService _notificationService;
        public OrderService(IPaymentProcessor paymentProcessor, INotificationService notificationService)
        {
            _paymentProcessor = paymentProcessor;
            _notificationService = notificationService;
        }
        public void PlaceOrder(Order order, Customer customer)
        {

            _paymentProcessor.ProcessPayment(order);
            _notificationService.SendNotification(customer, "Your order has been placed successfully!");
            Console.WriteLine("Order Processed for: " + customer.Name);
        }

        // -------------------- OCP: Extend Functionality Without Modification -------------------- //

        public interface IPaymentProcessor
        {
            void ProcessPayment(Order order);
        }

        public class CreditCardPaymentProcessor : IPaymentProcessor
        {
            public void ProcessPayment(Order order)
            {
                Console.WriteLine("Payment of " + order.Price + " processed via Credit Card.");
            }
        }
        public class DebitCardPaymentProcessor : IPaymentProcessor
        {
            public void ProcessPayment(Order order)
            {
                Console.WriteLine("Payment of " + order.Price + " processed via Debit Card.");
            }
        }
        public class NetBankingPaymentProcessor : IPaymentProcessor
        {
            public void ProcessPayment(Order order)
            {
                Console.WriteLine("Payment of " + order.Price + " processed via NetBanking.");
            }
        }
        public class PayPalPaymentProcessor : IPaymentProcessor
        {
            public void ProcessPayment(Order order)
            {
                Console.WriteLine("Payment of " + order.Price + " processed via PayPal.");
            }
        }
        public class UPIPaymentProcessor : IPaymentProcessor
        {
            public void ProcessPayment(Order order)
            {
                Console.WriteLine("Payment of " + order.Price + " processed via UPIPayment.");
            }
        }

        // -------------------- LSP: Substitutable User Types -------------------- //
        public class RegularCustomer : Customer
        {
            public void GetRegularDiscount()
            {
                Console.WriteLine("Applying regular customer discount...");
            }
        }
        public class VIPCustomer : Customer
        {
            public void GetVipDiscount()
            {
                Console.WriteLine("Applying VIP customer discount...");
            }
        }

        // -------------------- ISP: Separate Small Interfaces -------------------- //

        public interface INotificationService
        {
            void SendNotification(Customer customer, string message);
        }
        public class EmailNotificationService : INotificationService
        {
            public void SendNotification(Customer customer, string message)
            {
                Console.WriteLine($"Email notification sent to {customer.Email}: {message}");
            }
        }
        public class SMSNotificationService : INotificationService
        {
            public void SendNotification(Customer customer, string message)
            {
                Console.WriteLine($"SMS notification sent to {customer.Mobile}: {message}");
            }
        }

        // -------------------- DIP: Inject Dependencies -------------------- //
        //public class ProgramTwo
        //{
        //    static void Main(string[] args)
        //    {
        //        IPaymentProcessor paymentProcessor = new CreditCardPaymentProcessor();

        //        INotificationService notificationService = new EmailNotificationService();

        //        OrderService orderService = new OrderService(paymentProcessor, notificationService);

        //        VIPCustomer customer = new VIPCustomer { Id = 1, Name = "John Doe" };
        //        customer.GetVipDiscount();

        //        Order order = new Order { Id = 101, Price = 80000, Quantity = 50, ProductName = "Apple IPhone" };

        //        orderService.PlaceOrder(order, customer);

        //        Console.ReadLine();
        //    }
        //}

    }
}
