using Microsoft.AspNetCore.Mvc;
using Mobile_StoreAPI.Repository.IRepository;

namespace Mobile_StoreAPI
{
    public class ProductService : IProductService
    {
        readonly IRepository<Product> _productService;
        public ProductService(IRepository<Product> productService)
        {
            _productService = productService;
        }
        public IEnumerable<Product> getAllProduct()
        {
            return _productService.GetAll();
        }
        public Product GetProductById(int id)
        {
            return _productService.GetById(id);
        }
        public bool updateProduct(Product product)
        {
            _productService.Update(product);
            return true;
        }

        public async Task AddProduct(Product product)
        {
            await _productService.Add(product);
        }
        public bool DeleteProduct(int Id)
        {
            try
            {
                var dataList = _productService.GetAll().Where(x => x.Id == Id).ToList();
                foreach(var item in dataList)
                {
                    _productService.Delete(item);
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
