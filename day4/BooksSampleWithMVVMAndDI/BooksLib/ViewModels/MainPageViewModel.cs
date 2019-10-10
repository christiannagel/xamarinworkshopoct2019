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

        public MainPageViewModel(IBooksService booksService)
        {
            _booksService = booksService;

            AddBookCommand = new DelegateCommand(AddBook);
            RefreshBooksCommand = new DelegateCommand(RefreshBooks);
        }

        public DelegateCommand AddBookCommand { get; private set; }
        public DelegateCommand RefreshBooksCommand { get; private set; }

        private async void RefreshBooks()
        {
            await InitAsync();
        }

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

        public string Foo(string data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return data.ToLower();
        }

        public IEnumerable<Book> Books => _books;
    }
}
