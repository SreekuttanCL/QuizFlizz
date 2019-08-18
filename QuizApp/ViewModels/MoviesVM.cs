using System;
using System.Windows.Input;
using Xamarin.Forms;
using QuizApp.Model;

namespace QuizApp
{
    public class MoviesVM: BaseVM
    {
        public string trueTitle { get; set; }
        public string falseTitle { get; set; }

        public MoviesVM()
        {
            myApp = Application.Current as App;

            trueTitle = "TRUE";
            falseTitle = "False";
            allQuestion = new QuestionBank();
            QuestionLabel = allQuestion.MoviesQuestion[questionNumber].QuestionText;
            CurrentScore = "Score: 0 / 10";
        }

        public ICommand TrueCommand => new Command(TrueClicked);
        public ICommand FalseCommand => new Command(FalseClicked);
        public ICommand BackCommand => new Command(BackClicked);

        async public void TrueClicked()
        {
            Console.WriteLine("true btn clicked");
            SportstoBaseTrue(true, "movies");
            OnPropertyChanged();
        }

        async public void FalseClicked()
        {
            SportstoBaseTrue(false, "movies");
        }

        public void BackClicked()
        {
            myApp.Back();
        }
    }
}
