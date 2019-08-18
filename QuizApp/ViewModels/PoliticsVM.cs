using System;
using System.Windows.Input;
using QuizApp.Model;
using Xamarin.Forms;

namespace QuizApp
{
    public class PoliticsVM: BaseVM
    {
        public string trueTitle { get; set; }
        public string falseTitle { get; set; }

        public PoliticsVM()
        {
            myApp = Application.Current as App;

            trueTitle = "TRUE";
            falseTitle = "False";
            allQuestion = new QuestionBank();
            QuestionLabel = allQuestion.PoliticsQuestion[questionNumber].QuestionText;
            CurrentScore = "Score: 0 / 10";
        }

        public ICommand TrueCommand => new Command(TrueClicked);
        public ICommand FalseCommand => new Command(FalseClicked);
        public ICommand BackCommand => new Command(BackClicked);

        async public void TrueClicked()
        {
            SportstoBaseTrue(true,"politics");
            OnPropertyChanged();
        }

        async public void FalseClicked()
        {
            SportstoBaseTrue(false,"politics");
        }

        async public void BackClicked()
        {
            myApp.Back();
        }

        
    }
}
