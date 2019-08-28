using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using QuizApp.Tools;
using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class MyScore : ContentPage
    {
        SessionStore sessionStore;
        string username;
        Double medianScore = 0;

        List<Scores> customList;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public App myApp = Application.Current as App;



        public MyScore()
        {
            InitializeComponent();

        }



        protected async override void OnAppearing()
        {
            base.OnAppearing();
            initializeListView();
        }



        private async void Back(object sender, EventArgs e)
        {
            myApp.Back();
        }

        public double CalculateMedian(List<Scores> list)
        {
            double m=0;
            if (list.Count == 0)
            {
                m = 0;
            }
            else
            {
                foreach (var item in list)
                {
                    medianScore = medianScore + item.Score;

                }
                medianScore = medianScore / list.Count;
                m = Math.Round(medianScore, 2);
            }


           

            return m;
        }


        public async void  initializeListView()
        {
            sessionStore = new SessionStore();
            username = sessionStore.UserName.ToLower().ToString();
            Debug.Write(" username.." + username);
            // var allScores =  await firebase
            var allScores = await firebaseHelper.GetAllScores();

            customList = new List<Scores>();

            foreach (var item in allScores)
            {

                if (item.Username.Equals(username))
                {
                    customList.Add(item);

                }
            }
            //var asc = customList.OrderBy(item => item.Score);

            if (customList.Count == 0)
            {
                BtnAll.Text = "0";

                bool where = await App.Current.MainPage.DisplayAlert("Alert!", "You have not played any games.", "Play","Stay here.");
                if (where)
                {
                    myApp.OnLogin();
                }
                else
                {

                }
            }
            else
            {
                scoresListView.ItemsSource = customList;

                medianScore = CalculateMedian(customList);
                BtnAll.Text = medianScore.ToString();

            }

            //var leaderboardScores = await firebaseHelper.GetLeaderboardScores();
            //foreach(var item in leaderboardScores)
            //{
            //    if (item.Username.ToLower().ToString().Equals(sessionStore.UserName.ToLower().ToString()))
            //    {
            //        Debug.Write("inside update");
            //        await firebaseHelper.UpdateLeaderboard(username, medianScore.ToString());

            //    }
            //    else
            //    {
            //        Debug.Write("inside add");



            //        await firebaseHelper.AddScoreForLeaderboard(username, medianScore.ToString());



            //    }
            //}



        }
    }
}
