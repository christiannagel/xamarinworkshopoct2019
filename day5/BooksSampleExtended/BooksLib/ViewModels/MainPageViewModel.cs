using BooksLib.Services;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        private readonly IDialogService _dialogService;

        private readonly ObservableCollection<Book> _books = new ObservableCollection<Book>();

        public MainPageViewModel(
            IBooksService booksService, 
            IDialogService dialogService,
            ILogger<MainPageViewModel> logger)
        {
            _booksService = booksService;
            _dialogService = dialogService;
            _logger = logger;

            AddBookCommand = new DelegateCommand(AddBook);
            GetBookCommand = new DelegateCommand(OnGetBook);
            RefreshBooksCommand = new DelegateCommand(RefreshBooks);
        }

        public DelegateCommand AddBookCommand { get; private set; }
        public DelegateCommand GetBookCommand { get; private set; }
        public DelegateCommand RefreshBooksCommand { get; private set; }

        private async void RefreshBooks()
        {
            await InitAsync();
        }

        private void AddBook()
        {
            _books.Add(new Book { BookId = 42, Title = "new book", Publisher = "self" });
        }

        private async void OnGetBook()
        {
            Book? book = await _booksService.GetBookAsync(BookId);
        }

        public async Task InitAsync()
        {
            try
            {
                var books = await _booksService.GetBooksAsync();

                _books.Clear();
                foreach (var book in books)
                {
                    _books.Add(book);
                }

                if (_books.Count >= 1)
                {
                    SelectedBook = _books[0];
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await _dialogService.ShowDialogAsync("Error", "please try again later, or ask the admin");
            }
        }

        public IEnumerable<Book> Books => _books;

        private Book _selectedBook;

        public Book SelectedBook
        {
            get => _selectedBook;
            set => SetProperty(ref _selectedBook, value);
        }

        private int _bookId;
        public int BookId
        {
            get => _bookId;
            set => SetProperty(ref _bookId, value);
        }
    }
}
