using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TheBestMVVMFrameworkInTown.Net;

namespace BooksLib.Services
{
    public class ApiBooksService : IBooksService
    {
        private readonly IUrlConfiguration _urlConfiguration;
        private readonly HttpClient _httpClient;
        public ApiBooksService(HttpClient httpClient, IUrlConfiguration urlConfiguration)
        {
            _urlConfiguration = urlConfiguration;
            _httpClient = httpClient;
        }

        public async Task AddBookAsync(Book book) 
            => await _httpClient.AddItemAsync<Book>(_urlConfiguration.BooksService, book);

        public async Task<Book?> GetBookAsync(int id) 
            => await _httpClient.GetItemAsync<Book>($"{_urlConfiguration.BooksService}/{id}");

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var response = await _httpClient.GetAsync(_urlConfiguration.BooksService);
            string json = await response.Content.ReadAsStringAsync();
            var books = await _httpClient.GetItemsAsync<Book>(_urlConfiguration.BooksService);
            return books;
        }
    }
}
