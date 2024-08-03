

using Azure;
using Microsoft.EntityFrameworkCore;
using Mobile_StoreAPI.Models;
using Mobile_StoreAPI.Repository.IRepository;
using System.Runtime.CompilerServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace Mobile_StoreAPI
{
    public class BrandService : IBrandService
    {


        private readonly IRepository<Brand> brandsrepo;

        public BrandService(IRepository<Brand> _brandsrepo)
        {
            brandsrepo = _brandsrepo;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return brandsrepo.GetAll();
        }

        public async Task CreateBrand(Brand brand)
        {
            //throw new NotImplementedException();
            await brandsrepo.Add(brand);
        }

        public bool DeleteBrand(int Id)
        {
            try
            {
                var DataList = brandsrepo.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    brandsrepo.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public Brand GetBrandById(int id)
        {
            return brandsrepo.GetById(id);
        }

        public bool UpdateBrand(Brand brand)
        {
            brandsrepo.Update(brand);
            return true;
        }
        
    }
}
