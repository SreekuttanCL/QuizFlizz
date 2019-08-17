using System;
using Xamarin.Forms;
using System.Diagnostics;
using QuizApp.ViewModels;

namespace QuizApp
{
    public class Base : ContentPage
    {
        public App myApp = Application.Current as App;

        public Base()
        {
            SetbindingContext();
        }

        private void SetbindingContext()
        {
            if (this.GetType() == typeof(SportsPage))
                BindingContext = new SportsVM();
            else if (this.GetType() == typeof(PoliticsPage))
                BindingContext = new PoliticsVM();
            else if (this.GetType() == typeof(MainPage))
                BindingContext = new LoginPageVM();
            else if (this.GetType() == typeof(SignUp))
                BindingContext = new SignUpVM();
        }
    }
}
