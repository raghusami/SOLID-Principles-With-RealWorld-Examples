namespace SOLIDPrinciple._5_DependencyInversionPrinciple
{
    /*D – Dependency Inversion Principle (DIP)
    High-level modules should not depend on low-level modules. Both should depend on abstractions.
    Abstractions should not depend on details. Details should depend on abstractions.*/

    /* Bad Example */

    public class EmailService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }

    public class OrderServiceDIP
    {
        private EmailService _emailService;
        public OrderServiceDIP()
        {

            _emailService = new EmailService();
        }
        public void ProcessOrder()
        {
            Console.WriteLine("Processing order...");
            _emailService.SendEmail("Your order has been placed.");
        }
    }
    //class Program
    //{
    //    static void Main()
    //    {
    //        OrderServiceDIP orderService = new OrderServiceDIP();
    //        orderService.ProcessOrder();
    //    }
    //}

    /* Good Example */
    public interface IMessageService
    {
        void SendMessage(string message);
    }
    public class EmailServiceDIP : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }
    public class SMSService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }
    public class OrderService
    {
        private IMessageService _messageService;
        public OrderService(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public void ProcessOrder()
        {
            Console.WriteLine("Processing order...");
            _messageService.SendMessage("Your order has been placed.");
        }
    }
    //class ProgramTwo
    //{
    //    static void Main()
    //    {
    //        IMessageService emailService = new EmailServiceDIP();
    //        OrderService orderService = new OrderService(emailService);
    //        orderService.ProcessOrder();
    //    }
    //}
}
