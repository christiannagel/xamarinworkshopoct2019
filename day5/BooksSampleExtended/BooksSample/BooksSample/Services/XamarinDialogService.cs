using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksSample.Services
{
    public class XamarinDialogService : IDialogService
    {
        private readonly IXamarinPageService _pageService;
        public XamarinDialogService(IXamarinPageService pageService)
        {
            _pageService = pageService;
        }

        public async Task ShowDialogAsync(string title, string message)
        {
            // WPF
            //MessageBox.Show(title, message);
            //return Task.CompletedTask;

            // UWP
            // await new MessageDialog().ShowAsync(title, message);

            if (_pageService.Page == null) throw new InvalidOperationException("set the Page!!!");

            await _pageService.Page.DisplayAlert(title, message, "OK");
        }
    }
}
