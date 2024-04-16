using Library.Core.DTO;
using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using Library.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _categoriesServices;
        public CategoriesController(
            ICategoriesServices categoriesServices)
        {
            _categoriesServices = categoriesServices;
        }

        [HttpGet("id")]
        public IActionResult GetById(int id) 
        {
         return Ok(_categoriesServices.GetById(id));
        }
        [HttpPost]
        public IActionResult Add(CategoryDto dto)
        {
            var category = new Category() 
            {
                Name=dto.FullName
            };
            category= _categoriesServices.Add(category);
             return Ok(category);
        }
        //Upadte of category Name
        [HttpPut("id")]
        public IActionResult update(int id, [FromBody] CategoryDto dto)
        {
            if (id == null)
            { return NotFound($"this id {id} not fount"); }
            else
            {
                var category = _categoriesServices.GetById(id);

                category.Name= dto.FullName;
                return Ok(category);
            }
        }
        //Delete of category
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _categoriesServices.GetById(id);
            if (category == null)
                return NotFound("Not Found");
            category = _categoriesServices.Delete(id);

            return Ok("autror deleted");
        }
    }
}
