using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QuizApp
{
    public partial class SignUp : Base
    {
        public SignUp()
        {
            InitializeComponent();
        }


        void Signin_Clicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
