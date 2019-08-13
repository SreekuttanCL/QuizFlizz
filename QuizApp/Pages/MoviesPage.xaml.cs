using System;
using System.Collections.Generic;
using System.Diagnostics;
using QuizApp.Model;

using Xamarin.Forms;

namespace QuizApp
{
    public partial class MoviesPage : Base
    {
        
        QuestionBank allQuestion;
        bool pickedAnswer, correctAnswer;
        int questionNumber = 0;
        int score = 0;
        Double perQuestionProgress = .1;

        //pr

        void True_Handle_Clicked(object sender, System.EventArgs e)
        {

            pickedAnswer = true;
            checkAnswer();

        }

       

        void False_Handle_Clicked(object sender, System.EventArgs e)
        {

            pickedAnswer = false;
            checkAnswer();
        }

        void Back_Handle_Clicked(object sender, System.EventArgs e)
        {
            var onBack = Application.Current as App;
            onBack.Back();
        }

        public MoviesPage()
        {
            allQuestion = new QuestionBank();
            InitializeComponent();
            questionLabel.Text = allQuestion.question[questionNumber].QuestionText;
        }


        public void checkAnswer()
        {
         
               correctAnswer = allQuestion.question[questionNumber].CorrectAnswer;

                if(pickedAnswer == correctAnswer)
                {
                    score++;
                }

                MovieBar.ProgressTo(perQuestionProgress, 250, Easing.Linear);
                perQuestionProgress = perQuestionProgress + .1;
                currentScore.Text = "Score: " + score + "/10";
               
                questionNumber++;
                nextQuestion();

        }

    

        public void nextQuestion()
        {
            if(questionNumber < 10)
            {
                questionLabel.Text = allQuestion.question[questionNumber].QuestionText;

            }
            else
            {
                OnAlertYesNoClicked(null, null);
                currentScore.Text = "";
            }

        }
        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Results", "Your Final Score is " + score + "/10", "Continue", "Try Again");

            if (answer)
            {
                //send user to the category screen
                var myApp = Application.Current as App;
                myApp.Category();
            }
            else
            {
                //restart the activity
                var myApp = Application.Current as App;
                myApp.toMovies();
            }
        }
    }
}
