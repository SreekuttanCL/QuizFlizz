using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Firebase.Database;
using Firebase.Database.Query;
using QuizApp.Model;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
    public class ComicsVM : INotifyPropertyChanged
    {
        public QuestionBank allQuestion;
        bool pickedAnswer, correctAnswer;
        public int questionNumber = 0, score = 0;
        Double perQuestionProgress = .1;

        public string whichCat { get; set; }
        public App myApp = Application.Current as App;
        IList<Questions> QuestionList = new List<Questions>();
        public event PropertyChangedEventHandler PropertyChanged;
        FirebaseClient firebase = new FirebaseClient("https://xamarindatabase-ad351.firebaseio.com/");

        //initialize constructor
        public ComicsVM()
        {
            trueTitle = "TRUE";
            falseTitle = "False";
            MessagingCenter.Subscribe<string>(this, "sendCategory", (questionCategory) =>
            {
                Debug.Write("Messaging centre " + questionCategory);
                initializeList(questionCategory);

            }); 

        }


        //getters and setters start
        public ICommand TrueCommand => new Command(TrueClicked);
        public ICommand FalseCommand => new Command(FalseClicked);
        public ICommand BackCommand => new Command(BackClicked);
        public string nameOftheCategory { get; set; }
        public string trueTitle { get; set; }
        public string falseTitle { get; set; }

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

        public double startupProgress = 0.1;
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
        //getter and setters finish

            //button click event listeners start
        public void TrueClicked()
        {
            SportstoBaseTrue(true);
        }

        public void FalseClicked()
        {
            SportstoBaseTrue(false);
        }

        public void BackClicked()
        {
            myApp.Back();
        }

        //button click event listeners finish

            //Inotify property handler start
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
        //Inotify property handler finish

            //quiz logic start
        public void SportstoBaseTrue(bool _true)
        {
            pickedAnswer = _true;
            checkAnswer();
        }
         public void checkAnswer()
        {
            correctAnswer = QuestionList[questionNumber].answer;
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
                QuestionLabel = QuestionList[questionNumber].name;
            }
            else
            {
                OnAlertYesNoClicked(null, null);
                Debug.Write("in else ");
                CurrentScore = "";
            }
        }
        //quiz logic end

        //event listeners after quiz start
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
                myApp.toComics();
            }
        }
        //event listeners after quiz start

        //Retrieve list of all questions start
        public async Task<List<Questions>> GetAllPersons(string category)
        {
            Debug.Write("inside firebase function  "+ whichCat);

            return (await firebase
              .Child("Categories")
              .Child(category)
              .OnceAsync<Questions>()).Select(item => new Questions
              {
                  name = item.Object.name,
                  answer = item.Object.answer
              }).ToList();
        }
        //Retrieve list of all questions end

            //initialization of question
        public async void initializeList(string iCategory)
        {
            QuestionList = await GetAllPersons(iCategory);
            Debug.Write("Comics list: " + QuestionList.Count);
            allQuestion = new QuestionBank();
            QuestionLabel = QuestionList[questionNumber].name;
            CurrentScore = "Score: 0 / 10";
        }

            
    }
}
