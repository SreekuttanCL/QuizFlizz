using System;
using System.Collections.Generic;
using System.Diagnostics;
using QuizApp.ViewModels;
using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class ComicsPage : Base
    {
        public string cpCategory { get; set; }
        public ComicsPage()
        {
            MessagingCenter.Subscribe<string>(this, "refreshPage", (sender) =>
            {
                App.Current.MainPage = new NavigationPage(new ComicsPage());

            });
            InitializeComponent();

        }

    }
}
