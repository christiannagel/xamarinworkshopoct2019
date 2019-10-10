namespace BooksLib.Services
{
    public interface IUrlConfiguration
    {
        string BaseAddress { get; }
        string BooksService { get; }
    }
}