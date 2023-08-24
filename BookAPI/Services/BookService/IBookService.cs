using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace BookAPI.Services.BookService
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetSingleBook(int id);
        Task<List<Book>> AddBook(Book book);
        Task<List<Book>?> UpdateBook(int id, Book requestedBook);
        Task<Book?> UpdateBookSingleProp(int id, JsonPatchDocument<Book> bookUpdates);
        Task<List<Book>?> DeleteBook(int id);
    }
}
