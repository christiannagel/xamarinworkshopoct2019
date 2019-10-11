using BooksLib;
using BooksLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using BooksSample.Services;

namespace BooksSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            ViewModel = AppServices.Instance.Container.GetService<MainPageViewModel>();

            this.BindingContext = ViewModel;

            InitializeComponent();

            var pageService = AppServices.Instance.Container.GetService<IXamarinPageService>();
            pageService.Page = this;

            var _ = ViewModel.InitAsync();
        }

        public MainPageViewModel ViewModel { get; set; }

    }
}
