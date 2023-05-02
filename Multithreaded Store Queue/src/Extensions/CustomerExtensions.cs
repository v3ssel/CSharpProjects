namespace StoreSim {
    public static class CustomerExtensions {
        public static CashRegister? LeastOfCustomers(this Customer customer, List<CashRegister> cashiers) =>
            cashiers.MinBy(a => a.CashRegisterQueue.Count);
        
        public static CashRegister? LeastOfGoods(this Customer customer, List<CashRegister> cashiers) =>
            cashiers.MinBy(a => a.CashRegisterQueue.Sum(b => b.ShoppingCart));
    }
}
