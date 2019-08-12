using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QuizApp
{
    public partial class CategoryPage : MasterDetailPage
    {
        public CategoryPage()
        {
            var masterPage = new MasterPage(this);
            Master = masterPage;
            Detail = new NavigationPage(new MainDetails());

            InitializeComponent();
        }
    }
}
