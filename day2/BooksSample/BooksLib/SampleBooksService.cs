using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace BooksLib
{
    public class SampleBooksService : IBooksService
    {
        private readonly List<Book> _books = new List<Book>()
        {
            new Book {BookId = 1, Title = "Professional C# 7", Publisher = "Wrox Press"},
            new Book {BookId = 2, Title = "Professional C# 6", Publisher = "Wrox Press"},
            new Book {BookId = 3, Title = "Enterprise Services", Publisher = "AWL"},
            new Book {BookId = 4, Title = "Professional C# 9", Publisher = "Wrox Press"},

        };

        public Task<Book?> GetBookAsync(int id)
            => Task<Book?>.FromResult<Book?>(_books.SingleOrDefault(b => b.BookId == id));

        public Task<IEnumerable<Book>> GetBooksAsync()
            => Task<IEnumerable<Book>>.FromResult<IEnumerable<Book>>(_books);

        public Task AddBookAsync(Book book)
        {
            _books.Add(book);
            return Task.CompletedTask;
        }
    }
}
