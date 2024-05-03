using DIDemo.MAL;

namespace DIDemo.Repository
{
    public interface IProductRepository
    {
        int AddProduct(Product objProduct);
        List<Product> GetAll();
    }
}