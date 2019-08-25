﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QuizApp
{
    public partial class MainDetails : ContentPage
    {
        void Movies_Handle_Clicked(object sender, System.EventArgs e)
        {
            var Mpage = Application.Current as App;
            Mpage.toMovies();
        }

        void Sports_Handle_Clicked(object sender, System.EventArgs e)
        {
            var Spage = Application.Current as App;
            Spage.toSports("sports");
        }

        void Politics_Handle_Clicked(object sender, System.EventArgs e)
        {
        }

        public MainDetails()
        {
            InitializeComponent();
        }
    }
}