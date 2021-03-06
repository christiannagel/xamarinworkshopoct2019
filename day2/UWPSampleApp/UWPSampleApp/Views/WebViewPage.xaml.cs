﻿using System;

using UWPSampleApp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPSampleApp.Views
{
    public sealed partial class WebViewPage : Page
    {
        public WebViewViewModel ViewModel { get; } = new WebViewViewModel();

        public WebViewPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
