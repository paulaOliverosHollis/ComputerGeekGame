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
        private Random random = new Random();

        public MultipleChoiceQuestion(string question, Answers correctAnswer,
            string answerOption1, string answerOption2, string answerOption3, string answerOption4) : base(question)
        {
            _answerOptions = new List<string>() { answerOption1, answerOption2, answerOption3, answerOption4 };

            _correctAnswer = correctAnswer;
        }

        public override void PrintQuestion()
        {
            base.PrintQuestion();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine((Answers)i + $". {_answerOptions[i]}");
            }
        }

        public bool IsTheAnswerCorrect(Answers userAnswer)
        {
            return userAnswer == _correctAnswer;
        }

        public void RandomizeAnswers()
        {
            for (int i = 0; i < 5; i++)
            {
                // Indexes we want to swap
                int correctIndex = (int)_correctAnswer;
                int randomIndex = random.Next(0, 4);

                // Swap them ;)
                string temp = _answerOptions[correctIndex];
                _answerOptions[correctIndex] = _answerOptions[randomIndex];
                _answerOptions[randomIndex] = temp;

                _correctAnswer = (Answers)randomIndex;
            }
        }
    }
}
