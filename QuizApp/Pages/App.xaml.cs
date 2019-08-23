using System;
using System.Diagnostics;
using System.Threading.Tasks;
using QuizApp.ENUMS;
using QuizApp.Pages;
using QuizApp.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp
{
    public partial class App : Application
    {
        public PropertiesManager AppP;
        public SessionStore Session;

        public string cateegoryy { get; set; }
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
                    NavigateMainPage(Pagess.Landing);
                    break;
                case SessionStatus.LoggedInWithActiveSession:
                    NavigateMainPage(Pagess.AfterLogin);
                    break;
                case SessionStatus.LoggedInWithExpiredSession:
                    NavigateMainPage(Pagess.AfterLogin);
                    break;
                default:
                    NavigateMainPage(Pagess.Landing);
                    break;

            }

        }


        public Task NavigateMainPage(Pagess key)
        {

            switch (key)
            {
                case Pagess.Landing:
                    MainPage = new NavigationPage(new MainPage());

                    break;
                case Pagess.AfterLogin:
                    // MainPage = new AfterLoginPage();
                    MainPage = new NavigationPage(new HomeActivity());
                    break;
                default:
                    MainPage = new NavigationPage(new MainPage());
                    break;

            }
            return Task.FromResult(true);
        }
        public void OnLogin()
        {
            NavigateMainPage(Pagess.AfterLogin);

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
            NavigateMainPage(Pagess.Landing);
        }
        public void Category()
        {
            MainPage = new CategoryPage();
        }
        public void toMovies()
        {
            MainPage = new MoviesPage();
        }
        public void toSports(string hey)
        {
            MainPage = new SportsPage(hey);
        }
        public void toPolitics()
        {
            MainPage = new PoliticsPage();
        }

        public void toComics()
        {
            MainPage = new ComicsPage();
            //   Debug.Write("\nfrom app.xaml" + whichC);

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
