using BooksLib;
using Xamarin.Forms;

namespace BooksSample.Extensions
{
    public class BookTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WroxTemplate { get; set; }
        public DataTemplate DefaultBookTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //DataTemplate selectedTemplate = null;

            //if (item is Book book)
            //{
            // C# 1.0 switch statement
            //    switch (book.Publisher)
            //    {
            //        case "Wrox Press":
            //            selectedTemplate = WroxTemplate;
            //            break;
            //        default:
            //            selectedTemplate = DefaultBookTemplate;
            //            break;

            //    }
            //}
            //return selectedTemplate;

            // C# 8 switch expression
            return item switch
            {
                Book { Publisher: "Wrox Press" } => WroxTemplate,
                Book _ => DefaultBookTemplate,
                _ => null,            
            };
        }
    }
}
