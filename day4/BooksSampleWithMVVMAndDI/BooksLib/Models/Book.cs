using TheBestMVVMFrameworkInTown;

namespace BooksLib
{
    public class Book : BindableBase
    {
        public int BookId { get; set; }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string? _publisher;
        public string? Publisher
        {
            get => _publisher;
            set => SetProperty(ref _publisher, value);
        }

        private string? _isbn;

        public string? Isbn
        {
            get => _isbn;
            set => SetProperty(ref _isbn, value);
        }


        public string[] Authors { get; set; } = new string[0];

        public override string ToString() => Title;
    }
}
