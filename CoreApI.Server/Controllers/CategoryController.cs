using CoreApI.Server.Models;
using CoreApI.Server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService service)
        {
            _categoryService = service;
        }

        [HttpGet("GetAllCategories")]
      
        public IActionResult GetAllCategory() {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("GetCategoryByID/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCategoryByID(int id)
        {
            var category = _categoryService.GetByID(id);
            if (category == null)
                return NotFound($"Category with ID {id} not found");
            return Ok(category);
        }

        [HttpGet("GetCategoryByName/{name:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetCategoryByName(string name)
        {
            var category = _categoryService.GetByName(name);
            if (category == null)
                return NotFound($"Category with name '{name}' not found");
            return Ok(category);
        }

        [HttpGet("GetFirstCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetFirstCategory()
        {
            var category = _categoryService.GetFirstCategory();
            return Ok(category);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteCategory([FromQuery]int id)
        {
            var product = _categoryService.DeleteCategory(id);
            if (product != false)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AddCategory([FromForm] CategoryDTO category)
        {
            if (category == null)
               return BadRequest();
            _categoryService.AddCategory(category);

            return Ok();
        }

        [HttpPut("UpdateCategory/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateCategory(int id, [FromForm] CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var updated = _categoryService.UpdateCategory(id, category);

            if (!updated)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateCat(int id, [FromForm] CategoryDTO category)
        {
            if (category == null)
                return BadRequest();

            var Update = _categoryService.UpdateCat(id, category);

            if (Update)
            {
                return Ok();

            }
            return BadRequest();
        }
    }
}
