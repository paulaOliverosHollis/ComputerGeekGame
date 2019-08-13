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

    public class TrueOrFalseQuestion : Question
    {
        private bool _correctAnswer;

        public TrueOrFalseQuestion(string question, bool correctAnswer) : base(question)
        {
            _correctAnswer = correctAnswer;
        }

        public override void PrintQuestion()
        {
            base.PrintQuestion();
            Console.Write("\n\tTrue or False: ");
        }
    }

    public class MultipleChoiceQuestion : Question
    {
        public enum Answers { A, B, C, D }

        private Answers _correctAnswer;
        private List<string> _answerOptions = new List<string>();

        public MultipleChoiceQuestion(string question, string answerOption1, string answerOption2, string answerOption3, string answerOption4, Answers correctAnswer) : base(question)
        {
            _answerOptions.Add(answerOption1);_answerOptions.Add(answerOption2);_answerOptions.Add(answerOption3);_answerOptions.Add(answerOption4);
            _correctAnswer = correctAnswer;
        }

        public override void PrintQuestion()
        {
            base.PrintQuestion();

            foreach(var answer in _answerOptions)
            {
                Console.WriteLine(answer);
            }
        }
    }
}
