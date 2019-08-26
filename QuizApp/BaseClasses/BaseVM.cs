using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using QuizApp.Model;
using Xamarin.Forms;
using System.Reflection;
using QuizApp.ENUMS;

namespace QuizApp
{
    public class BaseVM: INotifyPropertyChanged
    {

        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetProperty(ref _IsBusy, value); }
        }
        protected App MainApp = Application.Current as App;



        public event PropertyChangedEventHandler PropertyChanged;

        public BaseVM()
        {
        }

        private async void TestAsync()
        {
            await Task.Delay(10000);
            Debug.WriteLine("got response from server");
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

       


        async public void ContinueSignIn(string _username, string _password)
        {
            Debug.WriteLine($"check against username:{_username}, password:{_password}");
            var _user = new UserAuthInfoObject
            {
                Email = _username,
                Password = _password,
                AuthType = AuthType.SignIn,
            };
            ServerConnect serviceConnect = new ServerConnect();

            IsBusy = true;
            var result = await serviceConnect.Connect(_user);

            switch (result)
            {
                case ServerReplyStatus.Success:
                    MainApp.OnLogin();
                    IsBusy = false;
                    break;
                case ServerReplyStatus.NotConfirmed:
                    await MainApp.MainPage.DisplayAlert("Error!", "Email not confirmed, \nPlease check your email to confirm your account", "Ok");
                    IsBusy = false;
                    break;
                case ServerReplyStatus.InvalidPassword:
                    await MainApp.MainPage.DisplayAlert("Error!", "Invalid password!", "Ok");
                    IsBusy = false;
                    break;
                case ServerReplyStatus.UserNotFound:
                    await MainApp.MainPage.DisplayAlert("Error!", "Username not found!", "Ok");
                    IsBusy = false;
                    break;
                default:
                    await MainApp.MainPage.DisplayAlert("Error!", "Something went wrong", "Ok");
                    IsBusy = false;
                    break;
            }

        }



    }
}
