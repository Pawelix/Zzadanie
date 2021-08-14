using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zadanie.Models;

namespace zadanie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly DataContext _context;
        public BookController(DataContext context)
        {
            _context = context;
        }

        // GET all Books
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> books = _context.Books;
            return View(books);
        }
        
         // GET Book with Id
        [HttpGet("details/{id}")]
        public async Task<ActionResult<Book>> Details(int Id)
        {
            var book = await _context.Books.FindAsync(Id);
            return View(book);
        }

        // GET Create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST Create
        [HttpPost("create")]
        public IActionResult Create([FromForm]Book book)
        {
            _context.Books.Add(book);            
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        // POST Delete
        [HttpGet("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _context.Books.Find(id);
            _context.Books.Remove(result);            
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        //GET Edit
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST Edit
        [HttpPost("edit/{id}")]
        public IActionResult Edit([FromForm]Book book)
        {
            _context.Books.Update(book);            
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}