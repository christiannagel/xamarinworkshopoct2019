using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSample
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // await CreateDatabaseAsync();
            // await CreateBooksAsync();
            await QueryBooksAsync();
        }

        private static async Task QueryBooksAsync()
        {
            using var context = new BooksContext();
            var books = context.Books.Where(b => b.Publisher == "Wrox Press").AsAsyncEnumerable();
            await foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} {book.Publisher}");
            }
        }

        private static async Task CreateBooksAsync()
        {
            using var context = new BooksContext();
            context.Books.Add(new Book { Title = "Professional C# 7", Publisher = "Wrox Press", Isbn = "4737834" });
            context.Books.Add(new Book { Title = "Professional C# 6", Publisher = "Wrox Press", Isbn = "343454" });
            await context.SaveChangesAsync();
        }


        // either EnsureCreated or migration
        private static async Task CreateDatabaseAsync()
        {
            using var context = new BooksContext();
            bool created = await context.Database.EnsureCreatedAsync();
            Console.WriteLine($"database created: {created}");

        }
    }
}
