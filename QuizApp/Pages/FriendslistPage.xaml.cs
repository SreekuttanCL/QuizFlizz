using System;
using System.Collections.Generic;
using System.Diagnostics;
using QuizApp.Model;
using QuizApp.Tools;
using Xamarin.Forms;

namespace QuizApp.Pages
{
    public partial class FriendslistPage : ContentPage
    {
        SessionStore sessionStore;
        public IList<User> modifiedList;
        string username;
        EventArgs e1;
        public App myApp = Application.Current as App;

        public FriendslistPage()
        {
            InitializeComponent();
        }

        FirebaseHelper firebaseHelper = new FirebaseHelper();


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await App.Current.MainPage.DisplayAlert("Alert", "Need ID to add, delete, update or retrieve.", "Got it.");

            initializeListView();
            BtnAll.TextColor = Color.DimGray;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {

            if (checkEmpty(txtId.Text) || checkEmpty(txtName.Text))
            {
                await DisplayAlert("Alert!", "Entry fields can not be emopy", "OK");
            }
            else
            {
                await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text, sessionStore.UserName);
                txtId.Text = string.Empty;
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person Added Successfully", "OK");
                initializeListView();
            }
        }
       
        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {

            if (checkEmpty(txtId.Text) )
            {
                await DisplayAlert("Alert!", "Entry fields can not be emopy", "OK");
            }
            else
            {
                var person = await firebaseHelper.GetPerson(Convert.ToInt32(txtId.Text));
                if (person != null)
                {
                    txtId.Text = person.UserId.ToString();
                    txtName.Text = person.Name;
                    await DisplayAlert("Success", "Person Retrive Successfully", "OK");

                }
                else
                {
                    await DisplayAlert("Success", "No Person Available", "OK");
                }
            }


        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (checkEmpty(txtId.Text) || checkEmpty(txtName.Text))
            {
                await DisplayAlert("Alert!", "Entry fields can not be emopy", "OK");
            }
            else
            {
                await firebaseHelper.UpdatePerson(Convert.ToInt32(txtId.Text), txtName.Text, username);
                txtId.Text = string.Empty;
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person Updated Successfully", "OK");
                initializeListView();
            }

        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (checkEmpty(txtId.Text) || checkEmpty(txtName.Text))
            {
                await DisplayAlert("Alert!", "Entry fields can not be emopy", "OK");
            }
            else
            {
                await firebaseHelper.DeletePerson(Convert.ToInt32(txtId.Text));
                await DisplayAlert("Success", "Person Deleted Successfully", "OK");
                initializeListView();
            }

        }

        private async void BtnMyFriends_Clicked(object sender, EventArgs e)
        {
            initializeListView();
            BtnMyFriends.TextColor = Color.White;
            BtnAll.TextColor = Color.DimGray;
        }

        private async void Back(object sender, EventArgs e)
        {
            myApp.Back();
        }

        private async void BtnAll_Clicked(object sender, EventArgs e)
        {
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
            BtnAll.TextColor = Color.White;
            BtnMyFriends.TextColor = Color.DimGray;

        }

        public async  void initializeListView()
        {
            sessionStore = new SessionStore();
            username = sessionStore.UserName.ToLower().ToString();
            var allPersons = await firebaseHelper.GetAllPersons();

            modifiedList = new List<User>();

            foreach (var item in allPersons)
            {
                Debug.Write("username is : " + item.OfOwner);

                if (item.OfOwner.ToLower().ToString().Equals(username))
                {
                    modifiedList.Add(item);
                }
            }
            if (modifiedList.Count == 0)
            {
                bool where = await App.Current.MainPage.DisplayAlert("Alert!", "You have not added any friends.", "Add now", "Add later");
                if (where)
                {
                    lstPersons.ItemsSource = modifiedList;
                }
                else
                {

                    myApp.OnLogin();

                }
            }
            else
            {
                lstPersons.ItemsSource = modifiedList;
            }
        }

        public  bool checkEmpty(string field)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
