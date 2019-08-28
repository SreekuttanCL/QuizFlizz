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
using QuizApp.Pages;
using QuizApp.Tools;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
    public class ComicsVM : INotifyPropertyChanged
    {
       // public QuestionBank allQuestion;
        bool pickedAnswer, correctAnswer;
        Double medianScore = 0;
        string uusername;
        public int questionNumber = 0, score = 0;
        Double perQuestionProgress = .1;
        SessionStore sessionStore;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public string whichCat { get; set; }
        public App myApp = Application.Current as App;
        IList<Questions> QuestionList = new List<Questions>();
        List<Scores> customList;

        public event PropertyChangedEventHandler PropertyChanged;
        FirebaseClient firebase = new FirebaseClient("https://xamarindatabase-ad351.firebaseio.com/");



        //initialize constructor
        public ComicsVM()
        {
            IsBusy = true;
            trueTitle = "TRUE";
            falseTitle = "FALSE";
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

        private bool _IsBusy =true;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetProperty(ref _IsBusy, value); }
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

        public async  void BackClicked()
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Warning!","Current Progress will be lost. Continue?", "Yes.", "Stay");

            if (answer)
            {
                myApp.Back();
            }

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
                App.Current.MainPage = new NavigationPage(new CategoryPage());
                sessionStore = new SessionStore();
                DateTime now = DateTime.Now.ToLocalTime();

                string currentTime = now.ToString();
                Debug.Write("Time is:" + currentTime);

                await AddScore(sessionStore.UserName, score, whichCat, currentTime);

                var allScores = await firebaseHelper.GetAllScores();
                Debug.Write("All scores " + allScores);

                customList = new List<Scores>();

                foreach (var item in allScores)
                {

                    if (item.Username.Equals(sessionStore.UserName))
                    {
                        customList.Add(item);
                        Debug.Write("Custom list score:" + item.Score);

                    }
                }
                medianScore = CalculateMedian(customList);

                var leaderboardScores = await firebaseHelper.GetLeaderboardScores();
                bool isUserInLeaderboard = true;
                foreach (var item in leaderboardScores)
                {
                    if (item.Username.ToLower().ToString().Equals(sessionStore.UserName.ToLower().ToString()))
                    {
                     Debug.Write("inside update");
                        isUserInLeaderboard = true;

                    }
                    else
                    {
                        isUserInLeaderboard = false;
                        Debug.Write("inside add");
                        
                    }
                }
                if (isUserInLeaderboard)
                {
                    await firebaseHelper.DeleteLeaderboard(sessionStore.UserName.ToLower().ToString());
                    await firebaseHelper.AddScoreForLeaderboard(sessionStore.UserName.ToLower().ToString(), medianScore.ToString());

                }
                else
                {
                await firebaseHelper.AddScoreForLeaderboard(sessionStore.UserName.ToLower().ToString(), medianScore.ToString());

                }
            }
            else
            {
                //restart the activity
                questionNumber = 0;
                score = 0;
                StartUpProgress = .1;
                perQuestionProgress = .1;
                QuestionLabel = QuestionList[questionNumber].name;
                CurrentScore = "Score: 0 / 10";
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
            questionNumber = 0;
            score = 0;
            QuestionList = await GetAllPersons(iCategory);
            whichCat = iCategory;
            //allQuestion = new QuestionBank();

            QuestionLabel = QuestionList[questionNumber].name;
            CurrentScore = "Score: 0 / 10";
            IsBusy = false;

        }

        public async Task AddScore(string _Username, int _score, string _categoryy, string _date )
        {
            await firebase
              .Child("Scores")
              .PostAsync(new Scores() { Username = _Username, Score = _score, Category=_categoryy, Date = _date });
        }

        public double CalculateMedian(List<Scores> list)
        {

            foreach (var item in list)
            {
                medianScore = medianScore + item.Score;
            }

            medianScore = medianScore / list.Count;
            double m = Math.Round(medianScore, 1);

            return m;
        }

    }
}
