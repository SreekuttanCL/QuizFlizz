﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using QuizApp.Model;
using Xamarin.Forms;
using System.Diagnostics;


namespace QuizApp
{
    public class SportsVM: BaseVM
    {
        public string trueTitle { get; set; }
        public string falseTitle { get; set; }

       

        public SportsVM()
        {

            //   Debug.Write("........sportsvm constructor:"+ myApp.globalCategory);
            myApp = Application.Current as App;

            trueTitle = "TRUE";
            falseTitle = "False";
            allQuestion = new QuestionBank();
            QuestionLabel = allQuestion.SportsQuestion[questionNumber].QuestionText;
            CurrentScore = "Score: 0 / 10";
       
        }

        public ICommand TrueCommand => new Command(TrueClicked);
        public ICommand FalseCommand => new Command(FalseClicked);
        public ICommand BackCommand => new Command(BackClicked);

        async public void TrueClicked()
        {
            Console.WriteLine("true btn clicked");
            SportstoBaseTrue(true,"sports");
            OnPropertyChanged();
        }

        async public void FalseClicked()
        {
            SportstoBaseTrue(false,"sports");
        }

        public void BackClicked()
        {
            myApp.Back();
        }

    }
}
