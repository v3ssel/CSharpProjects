namespace StoreSim {
    public class Store {
        public Storage StorageCapacity { get; set; }
        public List<CashRegister> Cashiers { get; }

        public Store(int capacity, int cnt_cashiers) {
            StorageCapacity = new Storage(capacity);
            CashRegister.InitCashiersTime();
            Cashiers = new List<CashRegister>(cnt_cashiers);
            for (var i = 0; i < cnt_cashiers; i++)
                Cashiers.Add(new CashRegister($"Register #{i + 1}"));
        }

        public List<Thread> OpenRegisters()
        {
            List<Thread> threads = new List<Thread>();
            foreach (var i in Cashiers)
            {
                threads.Add(new Thread(cash => {
                    while (i.CashRegisterQueue.Count > 0) {
                        Console.WriteLine($"{i.CurrentCustomer()}");
                        i.Proccess();
                    }
                }));
                threads.Last().Start();
            }
            return threads;
        }

        public bool IsOpen() =>
            !StorageCapacity.IsEmpty();
    }
}
