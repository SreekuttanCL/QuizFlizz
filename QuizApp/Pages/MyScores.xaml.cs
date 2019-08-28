    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using QuizApp.Tools;
using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class MyScores : ContentPage
    {
        //FirebaseClient firebase = new FirebaseClient("https://xamarindatabase-ad351.firebaseio.com/");
        List<Scores> customList;


        SessionStore sessionStore;
        string username;
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public MyScores()
        {
            InitializeComponent();

        }

        protected async void OnAppearing()
        {
            base.OnAppearing();
            sessionStore = new SessionStore();
            username = sessionStore.UserName.ToLower().ToString();
            Debug.Write(" username.." + username);
            // var allScores =  await firebase
           // var allScores = await firebaseHelper.GetAllScores();


            initializeListView();

        }

        private async void Back(object sender, EventArgs e)
        {
            
        }

        public async void initializeListView()
        {
            sessionStore = new SessionStore();
            username = sessionStore.UserName.ToLower().ToString();
            Debug.Write(" username.." + username);
            // var allScores =  await firebase
            var allScores = await firebaseHelper.GetAllScores();
            Debug.Write("All scores " + allScores);

            customList = new List<Scores>();

            foreach (var item in allScores)
            {
                Debug.Write("username is : " + item.Username);

                if (item.Username.Equals(username))
                {
                    customList.Add(item);
                    Debug.Write("Custom list score:" + item.Score);

                }
            }
            scoresListView.ItemsSource = customList;
        }
    }
}
