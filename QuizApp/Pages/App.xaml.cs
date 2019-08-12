using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public void onEnter()
        {
            MainPage = new CategoryPage();
        }
        public void LogOut()
        {
            MainPage = new MainPage();
        }
        public void Category()
        {
            MainPage = new CategoryPage();
        }
        public void toMovies()
        {
            MainPage = new MoviesPage();
        }
        public void toSports()
        {
            MainPage = new SportsPage();
        }
        public void toPolitics()
        {
            MainPage = new PoliticsPage();
        }
        public void Back()
        {
            MainPage = new CategoryPage();
        }
        public void onSignUp()
        {
            MainPage = new SignUp();
        }
        public void onsignin()
        {
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
