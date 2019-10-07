using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyAndroidApp
{
    public class BookFactory
    {
        private readonly List<Book> _books = new List<Book>()
        {
            new Book {Title = "Professional C# 7", Publisher = "Wrox Press"},
            new Book { Title = "Enterprise Services", Publisher = "AWL"}
        };

        public IEnumerable<Book> GetBooks() => _books;
    }
}