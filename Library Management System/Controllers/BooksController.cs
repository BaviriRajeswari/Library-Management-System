using Library_Management_System.Data;
using Library_Management_System.DTO;
using Microsoft.AspNetCore.Mvc;
using Library_Management_System.Model;

namespace Library_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _context.Books
                .Select(b => new BookResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Quantity = b.Quantity,
                    Price = b.Price
                })
                .ToList();

            return Ok(books);
        }
        [HttpPost]
        public IActionResult PostBook(BooksRequest request)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Price = request.Price,
                Quantity = request.Quantity
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(book);
        }
    }
}








    
