using System;
using System.Collections.Generic;
using QuizApp.Model;
using System.Diagnostics;

using Xamarin.Forms;

namespace QuizApp
{
    public partial class SportsPage : Base
    {
        public SportsPage()
        {
            
            InitializeComponent();
        }

        public SportsPage(String categoryName)
        {
            whichCategory = categoryName;
            Debug.WriteLine("from sports 2 " + categoryName + "");


        }
    }
}
