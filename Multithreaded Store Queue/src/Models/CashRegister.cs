using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;

namespace StoreSim {
    public class CashRegister : Object {
        private string Name { get; }
        public ConcurrentQueue<Customer> CashRegisterQueue;
        public int PastCustomers = 0;
        public static TimeSpan SecondsForCustomer { get; set; }
        public static TimeSpan SecondsForItem { get; set; }
        public TimeSpan WorkingTime { get; set; }

        public CashRegister(string name) {
            Name = name;
            WorkingTime = TimeSpan.Zero;
            CashRegisterQueue = new ConcurrentQueue<Customer>();
            if (SecondsForCustomer == TimeSpan.Zero || SecondsForItem == TimeSpan.Zero)
            {
                InitCashiersTime();
            }
        }

        public static void InitCashiersTime()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            SecondsForCustomer = TimeSpan.FromSeconds(int.Parse(configuration["SecondsForCustomer"]) < 1 ? 1 : int.Parse(configuration["SecondsForCustomer"]));
            SecondsForItem = TimeSpan.FromSeconds(int.Parse(configuration["SecondsForItem"]) < 1 ? 1 : int.Parse(configuration["SecondsForItem"]));
        }

        public void Proccess()
        {
            CashRegisterQueue.TryPeek(out Customer? current_customer);
            if (current_customer is not null)
            {
                var rnd = new Random();
                var per_item = TimeSpan.FromSeconds(rnd.NextInt64(1, (int)SecondsForItem.TotalSeconds));
                var per_cust = TimeSpan.FromSeconds(rnd.NextInt64(1, (int)SecondsForCustomer.TotalSeconds));
                WorkingTime += TimeSpan.FromSeconds(current_customer.ShoppingCart * per_item.TotalSeconds) + per_cust;
                Thread.Sleep(current_customer.ShoppingCart * per_item + per_cust);
                CashRegisterQueue.TryDequeue(out Customer? cst);
                Interlocked.Add(ref PastCustomers, 1);
            }
        }

        public override string ToString() =>
            $"{Name}";

        public string CurrentCustomer()
        {
            CashRegisterQueue.TryPeek(out Customer? current_customer);
            if (current_customer is not null)
            {
                return $"{current_customer} ({current_customer.ShoppingCart} items in cart) - " +
                       $"{Name} ({CashRegisterQueue.Count - 1} people with " + 
                       $"{CashRegisterQueue.Sum(a => a.ShoppingCart) - current_customer.ShoppingCart} items behind)";
            }
            return "";
        }
        
        public static bool operator ==(CashRegister cr1, CashRegister cr2) =>
            cr1.Name == cr2.Name;
        
        public static bool operator !=(CashRegister cr1, CashRegister cr2) =>
            !(cr1.Name == cr2.Name);
    }
}
