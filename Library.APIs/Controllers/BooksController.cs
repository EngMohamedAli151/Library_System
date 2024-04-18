using Library.Reposatory.Impelmentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Core.DTO;
using Library.DB.Model;
using Microsoft.Extensions.Options;
using Library.Services.Interface;
using Library.DB.Db_Context;
using Library.Reposatory.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Library.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region
        //private readonly IBaseRepository<Book> _autherRepository;
        //public BooksController(IBaseRepository<Book> autherRepository)
        //{
        //    _autherRepository = autherRepository;
        //}
        #endregion
        private readonly IBookServices _bookServices;
        public BooksController(
            IBookServices bookServices)
        {
            _bookServices=bookServices;
        }
        //GetById
        [HttpGet("GetById")]
        public IActionResult GetById(int id) { 
           var book= (_bookServices.Find(b => b.Id == id,new string[] { "Author","Category","Orders"} ));
            return Ok(book);
        }
        //GetAll
        [HttpGet]
        public IActionResult GetAll(string? FilterName)
        {
            if (FilterName == null)
            {
                return Ok( _bookServices.GetAll().ToList());
            }
            else
            {
                return Ok(_bookServices.FindAll(b => b.Title == FilterName, new[] { "Author", "Category", "Orders" }));
            }
        }
        //Add  Book
        [HttpPost("Add")]
        public IActionResult Add(BookDto dto)
        {
            var book = new Book()
            {
                Title = dto.Title,
                Description = dto.Description,
                AuthorId = dto.AuthorId,
                CatogoryId = dto.CatogeryId
            };
            var add = _bookServices.Add(book);
            return Ok(add);
        }
        //AddRange
        //[HttpPost("AddRange")]
        //public IActionResult AddRange(BookDto dto, IEnumerable<Book> entities)
        //{
        //     new Book()
        //    {
        //        Title = dto.Title,
        //        Description = dto.Description,
        //        AuthorId = dto.AuthorId,
        //        CatogoryId = dto.CatogeryId
        //    };
        //    var add = _bookServices.AddRange(entities);
        //    return Ok(add);

        //}


        //Upade Book
        [HttpPut("id")]
        public IActionResult Update(int id, [FromBody] BookDto dto)
        {

            var book = _bookServices.GetById(id) ;
            if (book == null)
            {
                return NotFound($"no book in this id={id}");
            }
            book.Title = dto.Title;
            book.Description = dto.Description;
            book.AuthorId = dto.AuthorId;
            book.CatogoryId = dto.CatogeryId;
            return Ok(book);
        }
        // Delet Book
        [HttpDelete("id")]
        public IActionResult Remove(int id)
        {

            var book = _bookServices.GetById(id);
            if (book == null)
            {
                return NotFound($"no book in this id={id}");
            }
            var result = _bookServices.Delete(id);
            return Ok(result);
        }

        [HttpGet("GetByAuthorId")]
        public IActionResult GetByAuthorId(int authorId)
        {
            var book = (_bookServices.FindAll(b => b.AuthorId == authorId,new string[] { "Category","Orders"}));
            return Ok(book);
        }
    }
}
