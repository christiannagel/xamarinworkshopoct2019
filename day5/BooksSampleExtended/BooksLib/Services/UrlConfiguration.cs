namespace BooksLib.Services
{
    public class UrlConfiguration : IUrlConfiguration
    {
        public string BaseAddress => "http://localhost:5000";

        public string BooksService => "/api/Books";
    }
}
