using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using QuizApp.ENUMS;
using QuizApp.Model;
using Xamarin.Forms;


namespace QuizApp.Pages
{
    public partial class HomeActivity : ContentPage
    {
        FirebaseClient firebase = new FirebaseClient("https://xamarindatabase-ad351.firebaseio.com/");
        public IList<Categories> categoriesList;
        public IList<Questions> sportsQuestionList;
        App myApp = Application.Current as App;


        protected  override void OnAppearing()
        {
        }

        public HomeActivity()
        {
            InitializeComponent();
            //intializeDatabase();

            categoriesList = new List<Categories>(){

                new Categories{name = "Movies",icons = "film-director-cinema-movies-clapperboard-512", detail ="'The Hurt Locker' won the..."},
                new Categories{name = "Comics",icons = "comics", detail="Superman was created by..."},
                new Categories{name = "Music",icons = "music" , detail = "Micheal Jackson topped the..."},
                new Categories{name = "Sports",icons = "sports", detail = "Celtic is an association football..."},
                new Categories{name = "Politics",icons = "politics", detail = "Socrates, the great Greek philosopher..."},
                new Categories{name = "History",icons = "history", detail = "Alexander the Great was the..."},
                new Categories{name = "Science",icons = "science", detail = "The longest bone in the..."},
                new Categories{name = "Countries",icons = "country", detail = "Singapore is the world's most densely..."},
                new Categories{name = "Animals",icons = "animals", detail = "A flamingo can only eat when..."},
                new Categories{name = "Human Body",icons = "anatomy", detail = "Women are born better smellers..."},
            };
            list.ItemsSource = categoriesList;
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Categories selectedItem = e.SelectedItem as Categories;

           myApp.toComics();
            MessagingCenter.Send(selectedItem.name.ToLower().ToString(), "sendCategory");
            DateTime now = DateTime.Now.ToLocalTime();
            //if (DateTime.Now.IsDaylightSavingTime() == true)
            //{
            //    now = now.AddHours(1);
            //}
            string currentTime = (string.Format("Current Time: {0}", now));
            Debug.Write("Time is:" + currentTime);
        }

        public async Task AddQuestion(string _name, bool _answer,string _categoryy)
        {
            await firebase
              .Child("Categories")
              .Child(_categoryy)
              .PostAsync(new Questions() { name = _name, answer = _answer });
        }
    }
}
