using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BooksLib.Services
{
    public class ApiBooksService : IBooksService
    {
        public Task AddBookAsync(Book book) => throw new NotImplementedException();
        public Task<Book?> GetBookAsync(int id) => throw new NotImplementedException();
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/api/Books");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
            return books;
        }
    }
}
