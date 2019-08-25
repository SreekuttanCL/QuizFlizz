using System;
using Xamarin.Forms;
using System.Diagnostics;
using QuizApp.ViewModels;
using QuizApp.Pages;
using QuizApp.ENUMS;
using System.Threading.Tasks;

namespace QuizApp
{
    public class Base : ContentPage
    {
        public string whichCategory { get; set; }
        public string nameC { get; set; }

        public App myApp = Application.Current as App;

        public Base()
        {
            SetbindingContext();


        }
        private bool CheckSession()
        {
            SessionStatus is_logged = myApp.Session.IsLoggedIn();
            return is_logged == SessionStatus.LoggedInWithActiveSession;
        }
        protected override void OnAppearing()
        {
            if (this.GetType() != typeof(MainPage)
               && this.GetType() != typeof(MasterPage)
               && this.GetType() != typeof(MainPage)
               && this.GetType() != typeof(SignUp)
               )
            {

                var response = CheckSession();
                if (!response)
                {
                    RefreshSession();
                    return;
                }
            }

        }
        private async Task RefreshSession()
        {
            var response = await myApp.MainPage.DisplayAlert("Attention!", "Your session is exprired!. Please choose what do you want to do", "Sign Out", "Refresh Session");
            if (response)
                myApp.LogOut();
            else DoRefreshSession();

        }

        private void DoRefreshSession()
        {
            Debug.WriteLine("refreshing session");
            var _myBinding = BindingContext as BaseVM;
            _myBinding.ContinueSignIn(myApp.Session.UserName, myApp.Session.UserPassword);
        }

        private void SetbindingContext()
        {
            if (this.GetType() == typeof(MainPage))
                BindingContext = new LoginPageVM();
            else if (this.GetType() == typeof(SignUp))
                BindingContext = new SignUpVM();
            else if (this.GetType() == typeof(ComicsPage)) { 
                BindingContext = new ComicsVM();
            }
        }
    }
}
