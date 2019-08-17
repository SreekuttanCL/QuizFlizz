using System;
using System.Threading.Tasks;
using QuizApp.ENUMS;
using QuizApp.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp
{
    public partial class App : Application
    {
        public PropertiesManager AppP;
        public SessionStore Session;

        public App()
        {
            AppP = new PropertiesManager();
            Session = new SessionStore();
            InitializeComponent();


            if (Properties.ContainsKey("Username"))
                OnLogin();
            else
                MainPage = new NavigationPage(new MainPage());



            SessionStatus is_logged = Session.IsLoggedIn();

            switch (is_logged)
            {
                case SessionStatus.LoggedOut:
                    NavigateMainPage(Pages.Landing);
                    break;
                case SessionStatus.LoggedInWithActiveSession:
                    NavigateMainPage(Pages.AfterLogin);
                    break;
                case SessionStatus.LoggedInWithExpiredSession:
                    NavigateMainPage(Pages.AfterLogin);
                    break;
                default:
                    NavigateMainPage(Pages.Landing);
                    break;

            }

        }


        public Task NavigateMainPage(Pages key)
        {

            switch (key)
            {
                case Pages.Landing:
                    MainPage = new NavigationPage(new MainPage());

                    break;
                case Pages.AfterLogin:
                    // MainPage = new AfterLoginPage();
                    MainPage = new NavigationPage(new CategoryPage());
                    break;
                default:
                    MainPage = new NavigationPage(new MainPage());
                    break;

            }
            return Task.FromResult(true);
        }
        public void OnLogin()
        {
            NavigateMainPage(Pages.AfterLogin);

        }

        public void onEnter()
        {
            MainPage = new CategoryPage();
        }
       async public void LogOut()
        {
            Properties.Remove("Username");
            Properties.Remove("Password");
            await SavePropertiesAsync();
            NavigateMainPage(Pages.Landing);
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
