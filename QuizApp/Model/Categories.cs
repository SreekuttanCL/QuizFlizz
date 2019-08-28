using System;
namespace QuizApp.Model
{
    public class Categories
    {
        public string name { get; set; }
        public string icons { get; set; }
        public string detail { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
