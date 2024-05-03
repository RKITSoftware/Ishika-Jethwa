using DIDemo.MAL;
using DIDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _ProductInstance;
        private readonly IProductRepository _ProductInstance2;

        public ProductController(IProductRepository productRepository,
            IProductRepository productInstance2)
        {
            _ProductInstance = productRepository;
            _ProductInstance2 = productInstance2;

        }

        [HttpPost,Route("AddProduct")]
        public IActionResult AddProduct([FromBody] Product objProduct)
        {
            _ProductInstance.AddProduct(objProduct);
            return Ok(_ProductInstance2.GetAll());
        }

    }
}
