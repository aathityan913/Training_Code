// Dependency interface
public interface IPaymentService
{
    void Pay();
}

// Concrete implementation
public class PaymentService : IPaymentService
{
    public void Pay()
    {
        Console.WriteLine("Payment processed!");
    }
}

// Another implementation
public class PaypalPaymentService : IPaymentService
{
    public void Pay()
    {
        Console.WriteLine("Payment processed via PayPal!");
    }
}

// Consumer class
public class OrderService
{
    private readonly IPaymentService _paymentService;

    // Dependency injected via constructor
    public OrderService(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public void PlaceOrder()
    {
        Console.WriteLine("Order placed.");
        _paymentService.Pay();
    }
}

// Program
class Program
{
    static void Main(string[] args)
    {
        // Inject dependency manually (can also use DI container)
        IPaymentService paymentService = new PaypalPaymentService();
        OrderService orderService = new OrderService(paymentService);

        orderService.PlaceOrder();
    }
}
