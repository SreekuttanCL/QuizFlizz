using System;

using Xamarin.Forms;

namespace QuizApp.Pages
{
    public class HomeActivity : ContentPage
    {
        public HomeActivity()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

