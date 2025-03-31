namespace SOLIDPrinciple._2_OpenClosedPrinciple
{
    public class PaymentOCP
    {
        /* O – Open/Closed Principle (OCP)
        Software entities (classes, modules, functions, etc.) 
        should be open for extension but closed for modification.

        This means we should be able to extend a class’s 
        behavior without modifying its existing code. */

        // Bad Example (Violating OCP) */
        public class PaymentProcess
        {
            public void ProcessPayment(string paymentType)
            {
                if (paymentType == "Credit Card")
                {
                    // Process credit card payment
                }
                else if (paymentType == "Debit Card")
                {
                    // Process debit card payment
                }
                else if (paymentType == "Net Banking")
                {
                    // Process net banking payment
                }
                else if (paymentType == "PayPal")
                {
                    // Process PayPal payment
                }
            }
        }

        // Good Example (Following OCP) */
        public interface IPayment
        {
            void ProcessPayment();
        }

        public class CreditCardPayment : IPayment
        {
            public void ProcessPayment()
            {
                Console.WriteLine("Processing Credit Card Payment...");
            }
        }
        public class DebitCardPayment : IPayment
        {
            public void ProcessPayment()
            {
                Console.WriteLine("Processing Debit Card Payment...");
            }
        }

        public class NetBankingPayment : IPayment
        {
            public void ProcessPayment()
            {
                Console.WriteLine("Processing NetBanking Payment...");
            }
        }
        public class PayPalPayment : IPayment
        {
            public void ProcessPayment()
            {
                Console.WriteLine("Processing PayPal Payment...");
            }
        }
        public class UIPPayment : IPayment
        {
            public void ProcessPayment()
            {
                Console.WriteLine("Processing UPI Payment...");
            }
        }
        public class PaymentProcessor
        {
            public void ProcessPayment(IPayment payment)
            {
                payment.ProcessPayment();
            }
        }
        //class Program
        //{
        //    static void Main()
        //    {
        //        PaymentProcessor processor = new PaymentProcessor();

        //        IPayment creditCard = new CreditCardPayment();
        //        IPayment upi = new UIPPayment();
        //        IPayment payPal = new PayPalPayment();
        //        IPayment netBanking = new NetBankingPayment();
        //        IPayment debitCard = new DebitCardPayment();

        //        processor.ProcessPayment(creditCard);
        //        processor.ProcessPayment(upi);
        //        processor.ProcessPayment(payPal);
        //        processor.ProcessPayment(netBanking);
        //        processor.ProcessPayment(debitCard);
        //    }
        //}
    }
}
