using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGeekGame
{
    public class Question
    {
        protected string _question;

        public Question(string question)
        {
            _question = question;
        }

        public virtual void PrintQuestion()
        {
            Console.WriteLine(_question);
        }
    }
}
