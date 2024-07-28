using LearningHorizonApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningHorizonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpPost]
        [RequestSizeLimit(104857600)]
        public async Task<IActionResult> CreateAsync([FromBody] AddBookModel model)
        {
            var bookImagePath = Path.Combine("Media", "Images", model.ImageFile.FileName);
            using (var stream = new FileStream(bookImagePath, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(stream);
            }
            var newBook = new Book
            {
                bookTitle = model.Tittle,
                bookDescription = model.Description,
                bookImageLink = bookImagePath,
                bookPrice = model.Price
            };
            if (model.BookFile != null)
            {
                var bookPath = Path.Combine("Media", "Books", model.BookFile.FileName);
                using (var stream = new FileStream(bookPath, FileMode.Create))
                {
                    await model.BookFile.CopyToAsync(stream);
                }
                newBook.bookPath = bookPath;
            }
            if (model.BookLink != null)
                newBook.bookLink = model.BookLink;

            await _context.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Book created successfully!" });
        }


        [HttpPut]
        [RequestSizeLimit(104857600)]
        public async Task<IActionResult> UpdateAsync([FromBody] AddBookModel model)
        {
            var book = await _context.Books.FindAsync(model.Id);
            if (book != null)
            {
                if(model.Tittle!=null) book.bookTitle = model.Tittle;
                if(model.Description!=null)book.bookDescription = model.Description;
                if(model.Price!=null)book.bookPrice = model.Price;
                if (model.ImageFile != null)
                {
                    if (!string.IsNullOrEmpty(book.bookImageLink) && System.IO.File.Exists(book.bookImageLink))
                    {
                        System.IO.File.Delete(book.bookImageLink);
                    }

                    var bookImagePath = Path.Combine("Media", "Images", model.ImageFile.FileName);
                    using (var stream = new FileStream(bookImagePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                    book.bookImageLink = bookImagePath;
                }
                if (model.BookFile != null)
                {
                    if (!string.IsNullOrEmpty(book.bookPath) && System.IO.File.Exists(book.bookPath))
                    {
                        System.IO.File.Delete(book.bookPath);
                    }

                    var bookPath = Path.Combine("Media", "Books", model.BookFile.FileName);
                    using (var stream = new FileStream(bookPath, FileMode.Create))
                    {
                        await model.BookFile.CopyToAsync(stream);
                    }
                    book.bookPath = bookPath;
                }
                if (model.BookLink != null) book.bookLink = model.BookLink;

                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Book updated successfully!" });
            }
            return NotFound(new { message = "Book not found." });
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound($"No Book was Found with ID : {id}");
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok(new { message = "Book deleted successfully!" });

        }

    }
}
