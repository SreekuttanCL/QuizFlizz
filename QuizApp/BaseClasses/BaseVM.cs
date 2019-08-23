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
        
       public QuestionBank allQuestion = new QuestionBank();
        bool pickedAnswer, correctAnswer;
        public int questionNumber = 0;
        int score = 0;
        Double perQuestionProgress = .1;
        public App myApp = Application.Current as App;
        protected App MainApp = Application.Current as App;
        public string nameOftheCategory { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        public BaseVM()
        {
        }

        private async void TestAsync()
        {
            await Task.Delay(10000);
            Debug.WriteLine("got response from server");
        }

        public string currentScore;
        public string CurrentScore
        {
            get
            {
                return currentScore;
            }
            set
            {
                SetProperty(ref currentScore, value);
            }
        }

        public double startupProgress =0.1;
        public double StartUpProgress
        {
            get
            {
                return startupProgress;
            }

            set
            {
                SetProperty(ref startupProgress, value);

                OnPropertyChanged("StartUpProgress");
            }
        }

        public string questionLabel;
        public string QuestionLabel
        {
            set
            {
                SetProperty(ref questionLabel, value);
            }
            get
            {
                return questionLabel;
            }
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



        async public void SportstoBaseTrue(bool _true)
        { 
            pickedAnswer = _true;
            checkAnswer();
        }
         async public void checkAnswer()
        {
            correctAnswer = allQuestion.question[questionNumber].CorrectAnswer;
            if (pickedAnswer == correctAnswer)
            {
                score++;
            }

            perQuestionProgress = perQuestionProgress + .1;
            StartUpProgress = perQuestionProgress;
            
            CurrentScore = "Score: " + score + "/10";


            questionNumber++;
            nextQuestion();
        }

        public void nextQuestion()
        {
            if (questionNumber < 10)
            {
                QuestionLabel = allQuestion.question[questionNumber].QuestionText;
            }
            else
            {
               OnAlertYesNoClicked(null, null);
                Debug.Write("in else ");
               CurrentScore = "";
            }
        }
        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Results", "Your Final Score is " + score + "/10", "Continue", "Try Again");

            if (answer)
            {
                //send user to the category screen
                var myApp = Application.Current as App;
                myApp.Category();
            }
            else
            {
                //restart the activity
                var myApp = Application.Current as App;
                myApp.toSports("sports");
            }
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


            var result = await serviceConnect.Connect(_user);
            
            switch (result)
            {
                case ServerReplyStatus.Success:
                    MainApp.OnLogin();
                    break;
                case ServerReplyStatus.NotConfirmed:
                    await MainApp.MainPage.DisplayAlert("Error!", "Email not confirmed, \nPlease check your email to confirm your account", "Ok");
                    break;
                case ServerReplyStatus.InvalidPassword:
                    await MainApp.MainPage.DisplayAlert("Error!", "Invalid password!", "Ok");
                    break;
                case ServerReplyStatus.UserNotFound:
                    await MainApp.MainPage.DisplayAlert("Error!", "Username not found!", "Ok");
                    break;
                default:
                    await MainApp.MainPage.DisplayAlert("Error!", "Something went wrong", "Ok");
                    break;
            }

        }



    }
}
