using System;
using System.Collections.Generic;

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
    }
}
