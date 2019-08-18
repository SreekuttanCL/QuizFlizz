using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using QuizApp.Model;
using Xamarin.Forms;
using System.Reflection;

namespace QuizApp
{
    public class BaseVM: INotifyPropertyChanged
    {
        
       public QuestionBank allQuestion = new QuestionBank();
        bool pickedAnswer, correctAnswer;
        public int questionNumber = 0;
        public string whichCategory;
        int score = 0;
        Double perQuestionProgress = .1;
        public App myApp { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public BaseVM()
        {

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



        async public void SportstoBaseTrue(bool _true, string _category)
        {
            whichCategory = _category;
            pickedAnswer = _true;
            checkAnswer();
        }
         async public void checkAnswer()
        {
            if (whichCategory == "politics")
            {
                correctAnswer = allQuestion.PoliticsQuestion[questionNumber].CorrectAnswer;
            }
            else if(whichCategory == "sports")
            {
                correctAnswer = allQuestion.SportsQuestion[questionNumber].CorrectAnswer;
            }
            else if (whichCategory == "movies")
            {
                correctAnswer = allQuestion.MoviesQuestion[questionNumber].CorrectAnswer;
            }
            
            Debug.Write("ITs clicking " + pickedAnswer);
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
                if (whichCategory == "politics")
                {
                    QuestionLabel = allQuestion.PoliticsQuestion[questionNumber].QuestionText;
                }
                else if (whichCategory == "sports")
                {
                    QuestionLabel = allQuestion.SportsQuestion[questionNumber].QuestionText;
                }
                else
                {
                    QuestionLabel = allQuestion.MoviesQuestion[questionNumber].QuestionText;
                }

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
                myApp.toSports();
            }
        }


    }
}
