using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksLib
{
    public interface IBooksService
    {
        Task AddBookAsync(Book book);
        Task<Book?> GetBookAsync(int id);
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}