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
        //{
        //    get
        //    {
        //        return _books;
        //    }
        //}

        private void OnAddBook(object sender, EventArgs e)
        {
            _books.Add(new Book { BookId = 42, Title = "a new book", Publisher = "Self" });
        }

        private void OnChangeBook(object sender, EventArgs e)
        {
            _books[0].Title = "Professional C# with .NET 5";
        }




        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty MyPropertyProperty =
            BindableProperty.Create("MyProperty", typeof(int), typeof(MainPage), 42);



        //public IEnumerable<Book> Books2
        //{
        //    get => _books;
        //}
    }
}
