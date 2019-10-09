using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TheBestMVVMFrameworkInTown;

namespace BooksLib.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IBooksService _booksService;
        private readonly ObservableCollection<Book> _books = new ObservableCollection<Book>();

        public MainPageViewModel()
        {
            _booksService = new SampleBooksService();

            AddBookCommand = new DelegateCommand(AddBook);
        }

        public DelegateCommand AddBookCommand { get; private set; }

        private void AddBook()
        {
            _books.Add(new Book { BookId = 42, Title = "new book", Publisher = "self" });
        }

        public async Task InitAsync()
        {
            var books = await _booksService.GetBooksAsync();

            _books.Clear();
            foreach (var book in books)
            {
                _books.Add(book);
            }
        }

        public IEnumerable<Book> Books => _books;

    }
}
