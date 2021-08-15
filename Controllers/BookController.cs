using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zadanie.Models;
using zadanie.Services;

namespace zadanie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly DataContext _context;
        private readonly IBooksService _service;
        public BookController(DataContext context, IBooksService service)
        {
            _service = service;
            _context = context;
        }

        // GET all Books
        [HttpGet]
        public IActionResult Index()
        {
            var books = _service.GetAll();
            return View(books);
        }

        // GET Book with Id
        [HttpGet("details/{id}")]
        public ActionResult<Book> Details(int id)
        {
            var result = _service.GetBook(id);
            if (result == null)
                return NotFound($"nie znaleziono ksiazki o id: {id}");
            
            return View(result);
        }

        // GET Create
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST Create
        [HttpPost("create")]
        public IActionResult Create([FromForm] Book book)
        {
            _service.AddBook(book);
            return RedirectToAction("index");
        }

        // POST Delete
        [HttpGet("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteBook(id);
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
        public IActionResult Edit([FromForm] Book book)
        {
            _service.UpdateBook(book);
            return RedirectToAction("index");
        }
    }
}