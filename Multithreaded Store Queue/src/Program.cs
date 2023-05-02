using StoreSim;

internal class Program
{
    private static string[] names = {"Andrew", "Hank", "Victor", "Ahmed", "Felicia",
                                     "Diana", "Kathe", "Donald", "Priscilla", "Robert",
                                     "Liliya", "Kadyr", "Shamil", "Anna", "Yakov",
                                     "Emilee", "Steve", "Lu Chan", "Huong Chi", "Margarita"};
    
    private static void CreateAndAddCustomer(Customer cst, Store store, Func<Customer, List<CashRegister>, CashRegister?> ChooseQueue)
    {
        cst.FillCart(7);
        if (store.StorageCapacity.Goods - cst.ShoppingCart < 0)
            Console.WriteLine($"{cst} ({cst.ShoppingCart - store.StorageCapacity.Goods} items left in cart.)");

        ChooseQueue(cst, store.Cashiers)!.CashRegisterQueue.Enqueue(cst);
        store.StorageCapacity.TakeGoods(store.StorageCapacity.Goods - cst.ShoppingCart > 0 
                                        ? cst.ShoppingCart : store.StorageCapacity.Goods);

        if (!store.IsOpen())
            return;
    }

    private static void MakeAndRunQueues(Store store, List<Customer> customers,
                                  Func<Customer, List<CashRegister>, CashRegister?> ChooseQueue)
    {
        Parallel.ForEach(customers, cst => {
            CreateAndAddCustomer(cst, store, ChooseQueue);
        });
        var threads = store.OpenRegisters();
        Timer timer = new Timer(a =>
            {
                if (!store.IsOpen())
                    return;
                
                var cst = new Customer(names[new Random().Next(names.Count())], customers.Count + 1);
                customers.Add(cst);
                CreateAndAddCustomer(cst, store, ChooseQueue);
            },
            null, TimeSpan.Zero, TimeSpan.FromSeconds(7)
        );
        foreach(Thread thread in threads) thread.Join();

        foreach (var i in store.Cashiers)
            Console.WriteLine($"{i}: Average Time Per Customer: {TimeSpan.FromSeconds(Math.Round(i.WorkingTime.TotalSeconds / (i.PastCustomers == 0 ? 1 : i.PastCustomers)))}");
    }

    private static void Main(string[] args)
    {
        List<Customer> customers = new List<Customer>();
        for (var i = 0; i < 10; i++)
            customers.Add(new Customer(names[i], i + 1));
        
        var store = new Store(50, 4);
        Console.WriteLine("\n====== LEAST BY CUSTOMERS NUMBER ======");
        MakeAndRunQueues(store, customers, CustomerExtensions.LeastOfCustomers);

        store = new Store(50, 4);
        Console.WriteLine("\n====== LEAST BY GOODS COUNT ======");
        MakeAndRunQueues(store, customers, CustomerExtensions.LeastOfGoods);        
    }
}
