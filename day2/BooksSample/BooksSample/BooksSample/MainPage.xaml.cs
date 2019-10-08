using BooksLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BooksSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly IBooksService _booksService;
        private readonly ObservableCollection<Book> _books = new ObservableCollection<Book>();

        public MainPage()
        {
            _booksService = new SampleBooksService();

            InitializeComponent();

            this.BindingContext = this;

            var _ = InitAsync();

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

        //public IEnumerable<Book> Books2
        //{
        //    get => _books;
        //}
    }
}
