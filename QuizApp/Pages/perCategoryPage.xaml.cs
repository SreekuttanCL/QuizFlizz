using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class perCategoryPage : ContentPage
    {

        public string category { get; set; }
        public perCategoryPage()
        {
            InitializeComponent();
        }
        public perCategoryPage(string name)
        {
            category = name;

        }
    }
}
