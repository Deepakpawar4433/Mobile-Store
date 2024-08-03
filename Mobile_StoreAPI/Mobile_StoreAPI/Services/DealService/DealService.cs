using Mobile_StoreAPI.Controllers;
using Mobile_StoreAPI.Models;
using Mobile_StoreAPI.Repository.IRepository;

namespace Mobile_StoreAPI
{
    public class DealService : IDealService
    {
        private readonly IRepository<Deals> _dealsrepo;

        public DealService(IRepository<Deals> dealsrepo)
        {
            _dealsrepo = dealsrepo;
        }
        public IEnumerable<Deals> GetAllDeals()
        {
            return _dealsrepo.GetAll();
        }
        public async Task AddDeal(Deals deal)
        {
            await _dealsrepo.Add(deal);
        }
        public Deals getDealById(int Id)
        {
            return _dealsrepo.GetById(Id);
        }
        public bool updateDeal(Deals deal)
        {
            _dealsrepo.Update(deal);
            return true;
        }
        public bool deleteDeal(int Id)
        {
            try
            {
                var dataList = _dealsrepo.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in dataList)
                {
                    _dealsrepo.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
