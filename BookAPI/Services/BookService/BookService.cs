using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace BookAPI.Services.BookService
{
    public class BookService : IBookService
    {
        
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }


        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetSingleBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
                return null;

            return book;
        }
        public async Task<List<Book>> AddBook(Book book)
        {
            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>?> UpdateBook(int id, Book requestedBook)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
                return null;

            book.Name = requestedBook.Name;
            book.Price = requestedBook.Price;
            book.Category = requestedBook.Category;
            book.Author = requestedBook.Author;

            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> UpdateBookSingleProp(int id, JsonPatchDocument<Book> bookUpdates)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
                return null;

            bookUpdates.ApplyTo(book);

            await _context.SaveChangesAsync();

            return book;
        }
        public async Task<List<Book>?> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
                return null;

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }
    }
}
