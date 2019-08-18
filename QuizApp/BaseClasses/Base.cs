using System;
using Xamarin.Forms;
using System.Diagnostics;

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
            if (this.GetType() == typeof(SportsPage)) {
                BindingContext = new SportsVM();
            }
                

            else if (this.GetType() == typeof(PoliticsPage))
                BindingContext = new PoliticsVM();
        }
    }
}
