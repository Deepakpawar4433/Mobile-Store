namespace Mobile_StoreAPI
{
    public interface IDealService
    {
        public IEnumerable<Deals> GetAllDeals();
        public Task AddDeal(Deals deal);
        public Deals getDealById(int Id);
        public bool updateDeal(Deals deal);
        public bool deleteDeal(int Id);
    }
}
