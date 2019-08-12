using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace QuizApp.Model
{
    public class QuestionBank : Question
    {
        //public Question question;

        public QuestionBank (){}

      public  List<Question> question = new List<Question>()
        {
            new Question { QuestionText = "'The Hurt Locker' won the Academy Award for Best picture in 2009", CorrectAnswer = true},
            new Question { QuestionText = "Gone with the wind was the first movie to win the Oscar for Best picture", CorrectAnswer = false},
            new Question { QuestionText = "LA filmed in Vancouver", CorrectAnswer = false},
            new Question { QuestionText = "Batman made his first movie apperance in the 1940s", CorrectAnswer = false},
            new Question { QuestionText = "Tom Hanks speaks less than 200 words in Toy Story 2 ", CorrectAnswer = false},
            new Question { QuestionText = "Paul Newman starred in the 1961 movie The Hustler", CorrectAnswer = true},
            new Question { QuestionText = "Academy Award or Oscar was first presented in 1929", CorrectAnswer = true},
            new Question { QuestionText = "Judy Garland did not star as Dorothy Gale in The Wizard of Oz", CorrectAnswer = false},
            new Question { QuestionText = "Ridley Scott was the director of the epic movie Gladiator in 2000", CorrectAnswer = true},
            new Question { QuestionText = "Tom Hanks played as Jack Dawson in Titanic", CorrectAnswer = false},
        };

       
    }
}
