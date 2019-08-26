using System;
using System.Windows.Input;
using QuizApp.Tools;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
    public class LoginPageVM:BaseVM
    {

        public string Username { get; set; }


        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        public ICommand SigninCommand => new Command(SignInClicked);
        public ICommand CreateAccount => new Command(SignUpClicked);

        //public object MainApp { get; private set; }

         public void SignInClicked()
        {
            CheckData();

        }

        public void SignUpClicked()
        {
            //var myApp = Application.Current as App;
            //myApp.onSignUp();
            App.Current.MainPage.Navigation.PushAsync(new SignUp());

        }
        public LoginPageVM()
        {
        }


        async void CheckData()
        {
            //Checking Email input
            if (!StringOperations.ValidateEmailInput(Username))
            {
                await App.Current.MainPage.DisplayAlert("Error!", "Please enter valid email", "ok");
                return;
            }

            //checking the password
            var result = StringOperations.BasicValidation(Password);
            if (result != null)
            {
                await App.Current.MainPage.DisplayAlert("Error!", result, "ok");
                return;
            }

            ContinueSignIn(Username, Password);
        }
    }
}
