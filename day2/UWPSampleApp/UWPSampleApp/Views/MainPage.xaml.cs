using System;

using UWPSampleApp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPSampleApp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
