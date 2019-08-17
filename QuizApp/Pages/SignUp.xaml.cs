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


        //void Signup_Clicked(object sender, System.EventArgs e)
        //{
        //    if (username.Text == null)
        //    {
        //        Error.Text = "Username is empty.";
        //    }
        //    else if (password.Text == null)
        //    {
        //        Error.Text = "Password is empty";
        //    }
        //    else if (ConfirmPassword.Text == null)
        //    {
        //        Error.Text = "Confirm password field is empty";
        //    }
        //    else if (password.Text != ConfirmPassword.Text)
        //    {
        //        Error.Text = "Password doesn't match";
        //    }
        //    else
        //    {
        //        var myApp = Application.Current as App;
        //        myApp.onEnter();
        //    }
        //}

        void Signin_Clicked(object sender, System.EventArgs e)
        {
            var myApp = Application.Current as App;
            myApp.onsignin();
        }
    }
}
