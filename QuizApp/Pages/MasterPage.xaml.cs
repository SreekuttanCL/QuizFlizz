using System;
using System.Collections.Generic;
using System.Diagnostics;
using QuizApp.Pages;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class MasterPage : ContentPage
    {
        MasterDetailPage myMaster;
        public MasterPage(MasterDetailPage _myMaster)
        {
            myMaster = _myMaster;
            InitializeComponent();
        }

        void Category_Handle_Clicked(object sender, System.EventArgs e)
        {
            //var CatClick = new NavigationPage(new MainDetails());
            //Navigation.PushAsync(CatClick);
            var CatClick = Application.Current as App;
            CatClick.Category();
        }

        void LogOut_Handle_Clicked(object sender, System.EventArgs e)
        {
            var logout = Application.Current as App;
            logout.LogOut();
        }

        void friendlist_Handle_Clicked(object sender, System.EventArgs e)
        {
            var friendlist = Application.Current as App;
            friendlist.toFriendlistPage();
        }
        void Scores_Handle_Clicked(object sender, System.EventArgs e)
        {
            var aboutUs = Application.Current as App;
            // aboutUs.toAboutUs();
            aboutUs.toMyScores();
            Debug.Write("clicked on scores..");

        }

        void Leaderboard_Handle_Clicked(object sender, System.EventArgs e)
        {
            var aboutUs = Application.Current as App;
            // aboutUs.toAboutUs();
            aboutUs.toLeaderboard();
            Debug.Write("clicked on scores..");

        }
        void aboutUs_Handle_Clicked(object sender, System.EventArgs e)
        {
            var aboutUs = Application.Current as App;
            // aboutUs.toAboutUs();
            App.Current.MainPage = new NavigationPage(new AboutUs());
             
        }


    }
}
