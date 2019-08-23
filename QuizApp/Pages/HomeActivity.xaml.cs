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


        protected async override void OnAppearing()
        {


        }

        public HomeActivity()
        {
            InitializeComponent();
            //intializeDatabase();

            categoriesList = new List<Categories>(){

                new Categories{name = "Movies"},
                new Categories{name = "Comics"},    
                new Categories{name = "Music"},
                new Categories{name = "Sports"},
                new Categories{name = "Politics"},
                new Categories{name = "History"},
                new Categories{name = "Science"},
                new Categories{name = "Countries"},
                new Categories{name = "Animals"},
                new Categories{name = "Human Body"},

            };

            list.ItemsSource = categoriesList;
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Categories selectedItem = e.SelectedItem as Categories;

            //myApp.toSports(selectedItem.name);
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
