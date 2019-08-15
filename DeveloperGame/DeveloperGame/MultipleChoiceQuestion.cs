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
            Random random = new Random();

            //I am storing the correct answer into a local variable so that way I can change its position in the list.
            string correctAnswer = _answerOptions[(int)_correctAnswer];
            _answerOptions.Remove(_answerOptions[(int)_correctAnswer]);

            int randomIndex = random.Next(0, 4);

            //After getting a random index number, I make sure to store the string that is already in that index into a local variable. Then I replace said string with the correct answer string. 
            string temp = _answerOptions[randomIndex];
            _answerOptions[randomIndex] = correctAnswer;

            // Then I add the string that was in the random index at the end of the list.
            _answerOptions.Add(temp);

            // I make sure to remember the new index where the correct answer is now located.
            _correctAnswer = (Answers)randomIndex;
        }
    }
}
