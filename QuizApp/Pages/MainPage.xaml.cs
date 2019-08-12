using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        void Enter_Handle_Clicked(object sender, System.EventArgs e)
        {
         
            if (username.Text == null)
            {
                Error.Text = "Username is empty";
            }
            else if(password.Text == null)
            {
                Error.Text = "Password is empty";
            }
            else
            {
                var myApp = Application.Current as App;
                myApp.onEnter();

            }

        }
        void Signup_Clicked(object sender, System.EventArgs e)
        {
            var myApp = Application.Current as App;
            myApp.onSignUp();
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
