
namespace QuizApp
{
    public class Question
    {
        public string QuestionText { get; set; }
        public bool CorrectAnswer { get; set; }

        public void ques(string text, bool ans)
        {
            QuestionText = text;
            CorrectAnswer = ans;
        }
    }
}
