using System;
using System.Windows.Input;
using QuizApp.Model;
using Xamarin.Forms;

namespace QuizApp
{
    public class PoliticsVM: Base
    {
        QuestionBank allQuestion;
        bool pickedAnswer, correctAnswer;
        int questionNumber = 0;
        int score = 0;
        Double perQuestionProgress = .1;

        public PoliticsVM() 
        {
            allQuestion = new QuestionBank();
           // questionLabel.Text = allQuestion.question[questionNumber].QuestionText;
        }

        public ICommand TrueCommand => new Command(TrueClicked);
        public ICommand FalseCommand => new Command(FalseClicked);
        public ICommand BackCommand => new Command(BackClicked);

        async public void TrueClicked()
        {
            pickedAnswer = true;
            checkAnswer();
        }

        async public void FalseClicked()
        {
            pickedAnswer = false;
            checkAnswer();
        }

        async public void BackClicked()
        {
            myApp.Back();
        }

        public void checkAnswer()
        {
            correctAnswer = allQuestion.question[questionNumber].CorrectAnswer;

            if (pickedAnswer == correctAnswer)
            {
                score++;
            }

           // PoliticsBar.ProgressTo(perQuestionProgress, 250, Easing.Linear);
            perQuestionProgress = perQuestionProgress + .1;
            //currentScore.Text = "Score: " + score + "/10";

            questionNumber++;
            nextQuestion();
        }

        public void nextQuestion()
        {
            if (questionNumber < 10)
            {
                //questionLabel.Text = allQuestion.question[questionNumber].QuestionText;

            }
            else
            {
                OnAlertYesNoClicked(null, null);
                // currentScore.Text = "";
            }
        }

        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            //bool answer = await DisplayAlert("Results", "Your Final Score is " + score + "/10", "Continue", "Try Again");

            //if (answer)
            //{
            //    //send user to the category screen
            //    var myApp = Application.Current as App;
            //    myApp.Category();
            //}
            //else
            //{
            //    //restart the activity
            //    var myApp = Application.Current as App;
            //    myApp.toMovies();
            //}
        }
    }
}
