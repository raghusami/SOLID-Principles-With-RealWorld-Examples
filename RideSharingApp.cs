//namespace SOLIDPrinciple
//{
//    // -------------------- SRP: Separate Responsibilities -------------------- //
//    // Ride Model
//    public class Ride
//    {
//        public int Id { get; set; }
//        public string RideType { get; set; } = string.Empty;
//        public double Price { get; set; }
//        public string PickupLocation { get; set; } = string.Empty;
//        public string DropLocation { get; set; } = string.Empty;
//    }

//    // Ride Booking Service
//    public interface IRideService
//    {
//        void BookRide(Ride ride, RideUser user);
//    }

//    public class RideService : IRideService
//    {
//        public void BookRide(Ride ride, RideUser user)
//        {
//            Console.WriteLine($"{user.Name} booked a {ride.RideType} ride from {ride.PickupLocation} to {ride.DropLocation}.");
//        }
//    }

//    // -------------------- OCP: Extend Functionality Without Modification -------------------- //
//    public interface IRideType
//    {
//        void RideDetails();
//    }

//    public class StandardRide : IRideType
//    {
//        public void RideDetails()
//        {
//            Console.WriteLine("Standard ride booked.");
//        }
//    }

//    public class LuxuryRide : IRideType
//    {
//        public void RideDetails()
//        {
//            Console.WriteLine("Luxury ride booked.");
//        }
//    }

//    public class BikeRide : IRideType
//    {
//        public void RideDetails()
//        {
//            Console.WriteLine("Bike ride booked.");
//        }
//    }

//    // -------------------- LSP: Substitutable User Types -------------------- //
//    public abstract class RideUser
//    {
//        public int Id { get; set; }
//        public string Name { get; set; } = string.Empty;
//    }

//    public class Driver : RideUser
//    {
//        public void AcceptRide(Ride ride)
//        {
//            Console.WriteLine($"Driver {Name} accepted the ride to {ride.DropLocation}.");
//        }
//    }

//    public class Passenger : RideUser
//    {
//        public void RequestRide(Ride ride, IRideService rideService)
//        {
//            rideService.BookRide(ride, this);
//        }
//    }

//    // -------------------- ISP: Interface Segregation -------------------- //
//    public interface IBookingService
//    {
//        void BookRide(Ride ride);
//    }

//    public interface IPaymentGateway
//    {
//        void ProcessPayment(double amount);
//    }

//    public interface IRideNotificationService
//    {
//        void SendNotification(string message);
//    }

//    public class PaymentService : IPaymentGateway
//    {
//        public void ProcessPayment(double amount)
//        {
//            Console.WriteLine($"Payment of ${amount} processed successfully.");
//        }
//    }

//    public class RideEmailNotificationService : INotificationService
//    {
//        public void SendNotification(string message)
//        {
//            Console.WriteLine("Email Notification: " + message);
//        }
//    }

//    // -------------------- DIP: Inject Dependencies -------------------- //
//    class RideProgram
//    {
//        static void Main()
//        {
//            IRideService rideService = new RideService();
//            IPaymentGateway paymentGateway = new PaymentService();
//            INotificationService notificationService = new EmailNotificationService();

//            Passenger passenger = new Passenger { Id = 1, Name = "Alice" };
//            Driver driver = new Driver { Id = 2, Name = "Bob" };

//            Ride ride = new Ride { Id = 1, RideType = "Luxury", PickupLocation = "Downtown", DropLocation = "Airport", Price = 50 };

//            passenger.RequestRide(ride, rideService);
//            driver.AcceptRide(ride);
//            paymentGateway.ProcessPayment(ride.Price);
//            notificationService.SendNotification("Your ride has been completed successfully.");
//        }
//    }
//}
