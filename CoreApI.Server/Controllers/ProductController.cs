using CoreApI.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext myDb; //DI for Database


        public ProductController(MyDbContext db)
        {
            myDb = db;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = myDb.Products.ToList();
            return Ok(products);
        }

        [HttpGet("GetByCategoryID")]
        public IActionResult GetAllProductsByCategory(int catID)
        {
            var products = myDb.Products.Where(x => x.CategoryId == catID).ToList();

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
            var product = myDb.Products.Find(id);
            return Ok(product);
        }

        [HttpGet("GetProductByname")]
        public IActionResult GetCategoryByName(string name)
        {
            var product = myDb.Products.SingleOrDefault(x => x.Name == name);
            return Ok(product);
        }

        [HttpGet("GetFirstProduct")]
        public IActionResult GetFirstCategory()
        {
            var product = myDb.Products.First();
            return Ok(product);
        }
    }
}
