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
    class BookListAdapter : BaseAdapter
    {
        private readonly Activity _activity;
        private readonly IList<Book> _books;


        public BookListAdapter(Activity activity, IList<Book> books)
        {
            _activity = activity;
            _books = books;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = _activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text 
                = $"{position}: {_books[position].Title}";
            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get => _books.Count;
        }

    }

    class BookListAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}