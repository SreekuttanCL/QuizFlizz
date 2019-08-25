
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
/*
 await AddQuestion("Queen had a 1991 Christmas number one with a re-issue of Bohemian Rhapsody.", true, "music");
            await AddQuestion("The Simpsons reached number one in the UK Singles Chart with Bart's single 'Do The Bartman' in 1991.", true, "music");
            await AddQuestion("Spice girls were the first group to have their first six singles all reach number one?", true, "music");
            await AddQuestion("Usher release the song 'You Make Me Wanna...' in 1998", false, "music");
            await AddQuestion("Without you was the name of Mariah Carey's first and to date only UK number one hit.", true, "music");
            await AddQuestion("Sir Elton John's middle name is Hercules.", true, "music");
            await AddQuestion("Elvis Presley has more than 15 number-one hits in the United States.", true, "music");
            await AddQuestion("'Walk this Way' was a hit for Guns N' Roses.", false, "music");*/
