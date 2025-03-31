namespace SOLIDPrinciple
{
    /*2. Inventory Management System
    ✅ SRP: Separate modules for stock management, order processing, and reporting.
    ✅ OCP: Support different inventory sources (local warehouse, third-party vendors).
    ✅ LSP: Allow different product types (Electronics, Furniture, Clothing).
    ✅ ISP: Interfaces for managing stock, pricing, and notifications.
    ✅ DIP: Inject dependencies (IStockService, IPricingStrategy).*/

    // -------------------- SRP: Separate Responsibilities -------------------- //
    // Product Model
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
    }

    // Stock Management Service
    public interface IStockService
    {
        void AddStock(Product product, int quantity);
        int GetStock(Product product);
    }

    public class LocalWarehouseStockService : IStockService
    {
        private readonly Dictionary<int, int> _stock = new Dictionary<int, int>();

        public void AddStock(Product product, int quantity)
        {
            if (_stock.ContainsKey(product.Id))
                _stock[product.Id] += quantity;
            else
                _stock[product.Id] = quantity;

            Console.WriteLine($"Added {quantity} units of {product.Name} to Local Warehouse.");
        }

        public int GetStock(Product product)
        {
            return _stock.ContainsKey(product.Id) ? _stock[product.Id] : 0;
        }
    }

    // -------------------- OCP: Extend Functionality Without Modification -------------------- //
    public interface IInventorySource
    {
        void FetchProduct(Product product);
    }

    public class ThirdPartyVendor : IInventorySource
    {
        public void FetchProduct(Product product)
        {
            Console.WriteLine($"Fetching {product.Name} from third-party vendor.");
        }
    }

    // -------------------- LSP: Substitutable Product Types -------------------- //
    public class Electronics : Product { }
    public class Furniture : Product { }
    public class Clothing : Product { }

    // -------------------- ISP: Interface Segregation -------------------- //
    public interface IPricingStrategy
    {
        double CalculatePrice(Product product);
    }

    public interface IInventoryNotificationService
    {
        void SendNotification(string message);
    }

    public class DiscountPricing : IPricingStrategy
    {
        public double CalculatePrice(Product product)
        {
            return product.Price * 0.9; // 10% discount
        }
    }

    public class EmailNotification : IInventoryNotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Email Notification: " + message);
        }
    }

    // -------------------- DIP: Inject Dependencies -------------------- //
    public class InventoryOrderService
    {
        private readonly IStockService _stockService;
        private readonly IPricingStrategy _pricingStrategy;
        private readonly IInventoryNotificationService _notificationService;

        public InventoryOrderService(IStockService stockService, IPricingStrategy pricingStrategy, IInventoryNotificationService notificationService)
        {
            _stockService = stockService;
            _pricingStrategy = pricingStrategy;
            _notificationService = notificationService;
        }

        public void ProcessOrder(Product product, int quantity)
        {
            int stock = _stockService.GetStock(product);
            if (stock >= quantity)
            {
                double price = _pricingStrategy.CalculatePrice(product) * quantity;
                Console.WriteLine($"Order processed for {quantity} {product.Name} at price: ${price}");
                _notificationService.SendNotification($"Order placed for {product.Name}");
            }
            else
            {
                Console.WriteLine($"Insufficient stock for {product.Name}.");
            }
        }
    }

    //class InventoryProgram
    //{
    //    static void Main()
    //    {
    //        IStockService stockService = new LocalWarehouseStockService();
    //        IPricingStrategy pricingStrategy = new DiscountPricing();
    //        IInventoryNotificationService notificationService = new EmailNotification();

    //        InventoryOrderService orderService = new InventoryOrderService(stockService, pricingStrategy, notificationService);

    //        Product laptop = new Electronics { Id = 1, Name = "Laptop", Price = 1000 };
    //        stockService.AddStock(laptop, 10);

    //        orderService.ProcessOrder(laptop, 2);
    //    }
    //}
}
