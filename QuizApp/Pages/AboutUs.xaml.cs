using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class AboutUs : ContentPage
    {
        public App myApp = Application.Current as App;
        public AboutUs()
        {
            InitializeComponent();
        }
        private async void Back(object sender, EventArgs e)
        {
            myApp.Back();
        }
    }
}
