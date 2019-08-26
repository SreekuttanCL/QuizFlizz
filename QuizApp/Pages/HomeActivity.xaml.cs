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
        //public IList<Icons> iconList;
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

                new Categories{name = "Movies",icons = "film-director-cinema-movies-clapperboard-512", detail =""},
                new Categories{name = "Comics",icons = "comics"},    
                new Categories{name = "Music",icons = "music"},
                new Categories{name = "Sports",icons = "sports"},
                new Categories{name = "Politics",icons = "politics"},
                new Categories{name = "History",icons = "history"},
                new Categories{name = "Science",icons = "science"},
                new Categories{name = "Countries",icons = "country"},
                new Categories{name = "Animals",icons = "animals"},
                new Categories{name = "Human Body",icons = "anatomy"},
            };
            list.ItemsSource = categoriesList;

            //iconList = new List<Icons>()
            //{
            //    new Icons{icons = "apple_ex"},
            //    new Icons{icons = "apple_ex.png"},
            //    new Icons{icons = "apple_ex.png"},
            //    new Icons{icons = "apple_ex.png"},
            //    new Icons{icons = "apple_ex.png"},
            //    new Icons{icons = "apple_ex.png"},
            //    new Icons{icons = "apple_ex.png"},
            //    new Icons{icons = "apple_ex.png"},
            //    new Icons{icons = "apple_ex.png"},
            //    new Icons{icons = "apple_ex.png"}
            //};
            //list.ItemsSource = iconList;

        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Categories selectedItem = e.SelectedItem as Categories;

           myApp.toComics();
            MessagingCenter.Send(selectedItem.name.ToLower().ToString(), "sendCategory");
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
