﻿using Library.Core.DTO;
using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using Library.Reposatory.Repository;
using Library.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorServices _authorServices;
        public AuthorsController(
            IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }
        //Select one Book
        [HttpGet("{id}")]
        public ActionResult GetById(int id) 
        {
            if (id == null)
            { return NotFound($"This Id={id}Not Exist"); }
            else { 
            return Ok(_authorServices.GetById(id));}
        }
        //Select All Author
        [HttpGet("GetAll")]
        public ActionResult GetAll() 
        {
                return Ok(_authorServices.GetAll().ToList());
        }
        //Create Of Author
        [HttpPost]
        public IActionResult Add( AuthorDto dto)
        {
            var author = new Author()
            { 
                FullName=dto.Name
            };
            var add = _authorServices.Add(author);
            return Ok(add);
        }
        //Create list of Author
        [HttpPost("AddRang")]
        public IActionResult AddRange(  IEnumerable<AuthorDto> dto)
        {
            List<Author> authorList = new List<Author>();   

            foreach (var item in dto)
            {
                Author author = new Author();
                    author.FullName = item.Name;
                
                authorList.Add(author);
            }
            var addRange = _authorServices.AddRange(authorList);
            return Ok(addRange);
        }
        //Upadte of Author Name
        [HttpPut("id")]
        public IActionResult update(int id, [FromBody] AuthorDto dto)
        {
            if (id == null)
            { return NotFound($"this id {id} not fount"); }
            else
            {
                var author = _authorServices.GetById(id);

                author.FullName = dto.Name ;
                return Ok(author);
            }
        }
        //Delete of Author
        [HttpDelete]
        public IActionResult Delete(int id) 
        { 
            var author= _authorServices.GetById(id);
            if (author == null)
                return NotFound("Not Found");
            author= _authorServices.Delete(id);
           
            return Ok("autror deleted");
        }
    }
    
}
