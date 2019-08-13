using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGeekGame
{
    public class MultipleChoiceQuestion : Question
    {
        public enum Answers { A, B, C, D }

        private Answers _correctAnswer;
        private List<string> _answerOptions;

        public MultipleChoiceQuestion(string question, Answers correctAnswer,
            string answerOption1, string answerOption2, string answerOption3, string answerOption4) : base(question)
        {
            _answerOptions = new List<string>() { answerOption1, answerOption2, answerOption3, answerOption4 };

            _correctAnswer = correctAnswer;
        }

        public override void PrintQuestion()
        {
            base.PrintQuestion();

            foreach (string answer in _answerOptions)
            {
                Console.WriteLine(answer);
            }
        }

        public bool IsTheAnswerCorrect(Answers userAnswer)
        {
            return userAnswer == _correctAnswer;
        }
    }
}
