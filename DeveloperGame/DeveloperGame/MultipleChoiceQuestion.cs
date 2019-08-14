using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerGeekGame
{
    public class MultipleChoiceQuestion : Question
    {
        public enum Answers { A, B, C, D}

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

            for(int i = 0; i < 4; i++)
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
            Random random = new Random();

            string correctAnswer = _answerOptions[(int)_correctAnswer];
            _answerOptions.Remove(_answerOptions[(int)_correctAnswer]);

            int randomIndex = random.Next(0, 3);

            string temp = _answerOptions[randomIndex];

            _answerOptions[randomIndex] = correctAnswer;

            _answerOptions.Add(temp);

            _correctAnswer = (Answers)randomIndex;
        }
    }
}
