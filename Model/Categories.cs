using System;
namespace QuizApp.Model
{
    public class Categories
    {
        public string name { get; set; }

        //public Categories(string _name)
        //{
        //    name = _name;
        //}

        public override string ToString()
        {
            return name;
        }
    }
}
