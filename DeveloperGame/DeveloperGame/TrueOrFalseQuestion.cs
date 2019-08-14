using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGeekGame
{
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
        }

        public bool IsTheAnswerCorrect(bool userAnswer)
        {
            return userAnswer == _correctAnswer;
        }
    }
}
