using DIDemo.MAL;

namespace DIDemo.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> lstProduct = new List<Product>();
        public int AddProduct(Product objProduct)
        {
            objProduct.Id = lstProduct.Count + 1;
            lstProduct.Add(objProduct);
            return objProduct.Id;
        }

        public List<Product> GetAll()
        {
            return lstProduct;
        }
    }
}
