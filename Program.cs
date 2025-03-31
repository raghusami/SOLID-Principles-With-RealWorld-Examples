using static SOLIDPrinciple.OrderService;

namespace SOLIDPrinciple
{

    // -------------------- DIP: Inject Dependencies -------------------- //
    public class Program
    {
        static void Main(string[] args)
        {
            IPaymentProcessor paymentProcessor = new CreditCardPaymentProcessor();

            INotificationService notificationService = new EmailNotificationService();
            
            OrderService orderService = new OrderService(paymentProcessor, notificationService);
           
            VIPCustomer customer = new VIPCustomer { Id = 1, Name = "John Doe" };
            customer.GetVipDiscount();

            Order order = new Order { Id = 101, Price = 80000,Quantity=50,ProductName="Apple IPhone" };
           
            orderService.PlaceOrder(order, customer);

            Console.ReadLine();
        }
    }
}