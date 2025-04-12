using CoreApI.Server.Models;
using CoreApI.Server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _ps;

        public ProductController(IProductService ps)
        {
            _ps = ps;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _ps.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("GetByCategoryID")]
        public IActionResult GetAllProductsByCategory(int catID)
        {

            var products = _ps.GetAllProductsByCategory(catID);

            if (products != null)
            { 
                return Ok(products);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetProductByID")]
        public IActionResult GetProductByID(int id)
        {
            var product = _ps.GetProductByID(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetProductByname")]
        public IActionResult GetProductByName(string name)
        {
            var product = _ps.GetProductByName(name);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetFirstProduct")]
        public IActionResult GetFirstCategory()
        {
            var product = _ps.GetFirstProduct();
            return Ok(product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _ps.DeleteProduct(id);
            if (product != false)
            {
                return Ok();
            }
            else {
                return NotFound();
            }
        }
    }
}
