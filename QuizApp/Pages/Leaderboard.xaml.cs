using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using QuizApp.Tools;
using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class Leaderboard : ContentPage
    {
        List<Leaderboard> customList;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public App myApp = Application.Current as App;
        SessionStore sessionStore;
        public Leaderboard()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            sessionStore = new SessionStore();
            initializeListView();
        }

        private async void Back(object sender, EventArgs e)
        {
            myApp.Back();
        }

        public async void initializeListView()
        {

            // var allScores =  await firebase
            var allScores = await firebaseHelper.GetLeaderboardScores();
                       

            bool ifExits = false;

            foreach (var item in allScores)
            {

                if (item.Username.ToLower().Equals(sessionStore.UserName.ToLower().ToString()))
                {
                    ifExits = true;
                }
                else
                {
                    ifExits = false;
                }
            }
            //var asc = customList.OrderBy(item => item.Score);

            if (!ifExits)
            {
                leaderScoresListView.ItemsSource = allScores;
                bool where = await App.Current.MainPage.DisplayAlert("Alert!", "You are not in leaderboard.", "Stay", "Play");
                if (where)
                {

                }
                else
                {
                    myApp.OnLogin();
                }
            }
            else
            {
                leaderScoresListView.ItemsSource = allScores;

            }

        }
    }
}
