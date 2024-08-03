

namespace Mobile_StoreAPI
{
    public interface IBrandService
    {
            public Task CreateBrand(Brand brand);

            public bool DeleteBrand(int Id);

            public bool UpdateBrand(Brand brand);

            public IEnumerable<Brand> GetAllBrands();

            public Brand GetBrandById(int id);
        
    }
}
