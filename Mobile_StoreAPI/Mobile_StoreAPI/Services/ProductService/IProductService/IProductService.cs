namespace Mobile_StoreAPI
{
    public interface IProductService
    {
        public IEnumerable<Product> getAllProduct();
        public Product GetProductById(int id);
        public bool updateProduct(Product product);
        public Task AddProduct(Product product);
        public bool DeleteProduct(int Id);
    }
}
