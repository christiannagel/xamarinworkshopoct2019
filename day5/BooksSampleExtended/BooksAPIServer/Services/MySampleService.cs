using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BooksAPIServer.Services
{
    public class MySampleService
    {
        private readonly HttpClient _httpClient;
        public MySampleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DoWork()
        {
            var response = await _httpClient.GetAsync("https://csharp.christiannagel.com");
            string content = await response.Content.ReadAsStringAsync();

        }
    }
}
