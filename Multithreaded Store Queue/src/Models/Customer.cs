namespace StoreSim {
    public class Customer : Object {
        private string Name { get; }
        private int SerialNumber { get; }
        public int ShoppingCart {
            get;
            private set;
        } = 0;


        public Customer(string name, int sn) {
            Name = name;
            SerialNumber = sn;
        }

        public void FillCart(int v) =>
            ShoppingCart = (int)new Random().NextInt64(1, v);

        public override string ToString() =>
            $"{Name}, customer #{SerialNumber}";

        public bool Equals(Customer obj) =>
            Name == obj.Name && SerialNumber == obj.SerialNumber;

        public static bool operator ==(Customer obj1, Customer obj2) =>
            obj1.Equals(obj2);

        public static bool operator !=(Customer obj1, Customer obj2) =>
            !obj1.Equals(obj2);
    }
}
