namespace StoreSim {
    public class Storage {
        public int Goods;
        public Storage(int goods) {
            Goods = goods;
        }

        public void TakeGoods(int count)
        {
            Interlocked.Add(ref Goods, -count);
        }

        public bool IsEmpty() =>
            Goods == 0;
    }
}
