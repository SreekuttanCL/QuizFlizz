using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using QuizApp.Model;
using Xamarin.Forms;

namespace QuizApp
{
    public class SportsVM: BaseVM
    {
        public string trueTitle { get; set; }
        public string falseTitle { get; set; }
               

        public SportsVM()
        {
            trueTitle = "TRUE";
            falseTitle = "False";
            allQuestion = new QuestionBank();
            QuestionLabel = allQuestion.question[questionNumber].QuestionText;
            CurrentScore = "Score: 0 / 10";
       
        }

        public SportsVM(string category)
        {
            nameOftheCategory = category;
            Debug.WriteLine("from sportsVM" + category + "");

        }

        public ICommand TrueCommand => new Command(TrueClicked);
        public ICommand FalseCommand => new Command(FalseClicked);
        public ICommand BackCommand => new Command(BackClicked);

        async public void TrueClicked()
        {
            Console.WriteLine("true btn clicked");
            SportstoBaseTrue(true);
            OnPropertyChanged();
        }

        async public void FalseClicked()
        {
            SportstoBaseTrue(false);
        }

        public void BackClicked()
        {
            myApp.Back();
        }

    }
}
