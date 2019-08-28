using System;
using System.Diagnostics;
using System.Windows.Input;
using QuizApp.ENUMS;
using QuizApp.Model;
using QuizApp.Tools;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
    public class SignUpVM: BaseVM
    {


        public ICommand SignUpCommand => new Command(SignUpClicked);
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordVerif { get; set; }

        private ServerConnect serviceConnect => new ServerConnect();
        public SignUpVM()
        {
        }

        async void SignUpClicked()
        {

            DataCheck();

        }


        async void DataCheck()
        {
            //Checking Email input
            if (!StringOperations.ValidateEmailInput(UserName))
            {
                await MainApp.MainPage.DisplayAlert("Error!", "Please enter valid email", "ok");
                return;
            }

            //checking the password
            var result = StringOperations.BasicValidation(Password);
            if (result != null)
            {
                await MainApp.MainPage.DisplayAlert("Error!", result, "ok");
                return;
            }

            if (!StringOperations.ValidatePasswordInput(Password))
            {
                await MainApp.MainPage.DisplayAlert("Error!", "Password must be 8 characters long with a number, uppercase, lowercase, and a special character", "ok");
                return;
            }


            if (Password != PasswordVerif)
            {
                await MainApp.MainPage.DisplayAlert("Error!", "Password verify mismatch", "ok");
                return;
            }



            ContinueSignUp();
        }




        async void ContinueSignUp()
        {
            Debug.WriteLine($"am sign up clicked: username:{UserName}, password:{Password}");
            var _user = new UserAuthInfoObject
            {
                Email = UserName,
                Password = Password,
                AuthType = AuthType.SignUp,
            };


            var result = await serviceConnect.Connect(_user);
            
            switch (result)
            {
                case ServerReplyStatus.Fail:
                    //  App.Current.MainPage.DisplayAlert("Error!", "Please enter valid email", "ok");
                    await App.Current.MainPage.DisplayAlert("Error!", "Something bad has occured", "Ok");
                    break;
                case ServerReplyStatus.UserNameAlreadyUsed:
                    await App.Current.MainPage.DisplayAlert("Error!", "Username already exists!", "Ok");
                    break;
                case ServerReplyStatus.PasswordRequirementsFailed:
                   await  App.Current.MainPage.DisplayAlert("Error!", "Password policy mismatch!", "Ok");
                    break;
                case ServerReplyStatus.Success:
                  await  App.Current.MainPage.DisplayAlert("Success", "Sign up succeeded!. \nPlease check you email for activating your account before logging in", "Ok");
                    break;
            }
        }




    }
}
