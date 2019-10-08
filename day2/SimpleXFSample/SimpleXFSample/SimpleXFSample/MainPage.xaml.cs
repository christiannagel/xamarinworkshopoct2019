using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleXFSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.BindingContext = this;
            InitializeComponent();
            Grid.SetRow(button1, 1);
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            button1.Text = "after click";
            Grid.SetRow(button1, 0);
        }

        public string Foo { get; set; } = "this is foo";
    }
}
