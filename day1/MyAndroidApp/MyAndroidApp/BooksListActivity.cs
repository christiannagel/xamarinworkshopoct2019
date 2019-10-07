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
    [Activity(Label = "BooksListActivity")]
    public class BooksListActivity : ListActivity
    {
        private List<Book> _books;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            _books = new List<Book>(new BookFactory().GetBooks());

            ListAdapter = new BookListAdapter(this, _books);
            // ListAdapter = new ArrayAdapter<Book>(this, Android.Resource.Layout.SimpleListItem1, _books); 
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            // base.OnListItemClick(l, v, position, id);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage($"clicked {_books[position]}").SetTitle(Android.Resource.String.Ok);

            AlertDialog dialog = builder.Create();
            dialog.Show();
        }
    }
}