using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BooksLib
{
    public class SampleBooksService : IBooksService
    {
        private readonly ILogger _logger;

        public SampleBooksService(ILogger<SampleBooksService> logger)
        {
            _logger = logger;
        }

        private readonly List<Book> _books = new List<Book>()
        {
            new Book {BookId = 1, Title = "Professional C# 7", Publisher = "Wrox Press"},
            new Book {BookId = 2, Title = "Professional C# 6", Publisher = "Wrox Press"},
            new Book {BookId = 3, Title = "Enterprise Services", Publisher = "AWL"},
            new Book {BookId = 4, Title = "Professional C# 9", Publisher = "Wrox Press"},
            new Book { BookId = 5, Title = "Beginning Visual C#", Publisher = "Wrox Press",
            Authors =
                new string[]
                {
                    "Karli Watson", "Christian Nagel", "Jay Glynn"
                }}
        };

        public Task<Book?> GetBookAsync(int id)
            => Task<Book?>.FromResult<Book?>(_books.SingleOrDefault(b => b.BookId == id));

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            _logger.LogInformation("GetBooksAsync invoked");
            return Task<IEnumerable<Book>>.FromResult<IEnumerable<Book>>(_books);
        }

        public Task AddBookAsync(Book book)
        {
            _logger.LogInformation("AddBooksAsync invoked");
            _books.Add(book);
            return Task.CompletedTask;
        }
    }
}
