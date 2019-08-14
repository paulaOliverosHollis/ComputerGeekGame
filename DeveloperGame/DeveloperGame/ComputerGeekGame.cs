using System;
using System.Collections.Generic;
using System.IO;


namespace ComputerGeekGame
{
    public class ComputerGeekGame
    {
        private string _scoreBoardFileName = "ComputerGeekLeaderBoard.txt";
        private List<Score> _leaderBoard = new List<Score>();
        private List<MultipleChoiceQuestion> _multipleChoiceQuestions;
        private List<TrueOrFalseQuestion> _trueOrFalseQuestions;

        public ComputerGeekGame()
        {
            try
            {
                if (File.Exists(_scoreBoardFileName))
                {
                    ReadScoresFromFile();
                }
                else
                {
                    FileStream stream = File.Create(_scoreBoardFileName);
                    stream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nSomething went wrong when trying to load the leaderboard. The following error was generated: {e.Message} Please exit the game and try again.");
            }
            
            MultipleChoiceQuestion question1 = new MultipleChoiceQuestion("\n\nWho was the first computer programmer?", MultipleChoiceQuestion.Answers.B, "Charles Babbage", "Ada Lovelace", "Grace Hopper", "Alan turing");
            MultipleChoiceQuestion question2 = new MultipleChoiceQuestion("\n\nWhich of the following was the first electrical computer: ", MultipleChoiceQuestion.Answers.A, "Collossus 1", "ENIAC", "Harvard Mark 1", "Pegassus I");
            MultipleChoiceQuestion question3 = new MultipleChoiceQuestion("\n\nWho invented the first computer?", MultipleChoiceQuestion.Answers.C, "Ada Lovelace", "Aiken H. Howard", "Charless Babbage", "Tommy Flowers");
            MultipleChoiceQuestion question4 = new MultipleChoiceQuestion("\n\nThe very first computer bug was a moth found in one of the following computers: ", MultipleChoiceQuestion.Answers.B, "Harvard Mark I", "Harvard Mark II", "Colossus Mark 1", "ENIAC");
            MultipleChoiceQuestion question5 = new MultipleChoiceQuestion("\n\nWhich of the following was the first mechanical computer:", MultipleChoiceQuestion.Answers.D, "The Analytical Engine", "The Tabulating Machine", "The Mathematical Engine", "The Difference Engine");
            TrueOrFalseQuestion question6 = new TrueOrFalseQuestion("\n\nTrue or False: The ENIAC was the first general purpose, programmable, electronic computer.", true);
            TrueOrFalseQuestion question7 = new TrueOrFalseQuestion("\n\nTrue or False: The Abacus is considered the very first computing device.", true);
            TrueOrFalseQuestion question8 = new TrueOrFalseQuestion("\n\nTrue or False: The Difference Engine was never actually created.", false);
            TrueOrFalseQuestion question9 = new TrueOrFalseQuestion("\n\nTrue or False: Harvard Mark I was one of the first computers which were powered by vacuum tubes.", false);
            TrueOrFalseQuestion question10 = new TrueOrFalseQuestion("\n\nTrue or False: The ENIAC is estimated to have done more arithmetic calculations than the entire human race up to that point.", true);

            _multipleChoiceQuestions = new List<MultipleChoiceQuestion>() { question1, question2, question3, question4, question5 };
            _trueOrFalseQuestions = new List<TrueOrFalseQuestion>() { question6, question7, question8, question9, question10 };
        }

        public void Run()
        {
            PrintIntro();

            char userMenuChoice;

            do
            {
                userMenuChoice = GetUserMenuChoice();

                if (UserChoseToPlay(userMenuChoice))
                {
                    Play();
                }
                else if (UserChoseToSeeLeaderBoard(userMenuChoice))
                {
                    PrintLeaderBoard();
                }

            } while (!UserChoseToQuit(userMenuChoice));
        }

        private void ReadScoresFromFile()
        {
            StreamReader reader = File.OpenText(_scoreBoardFileName);

            string line = reader.ReadLine();

            while (line != null)
            {
                string[] nameScoreTime = line.Split(' ');

                if (nameScoreTime.Length == 3)
                {
                    bool isScoreConvertible = int.TryParse(nameScoreTime[1], out int scoreResult);
                    bool isTimeConvertible = TimeSpan.TryParse(nameScoreTime[2], out TimeSpan timeResult);

                    if (!string.IsNullOrWhiteSpace(nameScoreTime[0]) && isScoreConvertible && isTimeConvertible)
                    {
                        _leaderBoard.Add(new Score(nameScoreTime[0], scoreResult, timeResult));
                    }
                }

                line = reader.ReadLine();
            }

            reader.Close();
        }

        private void PrintIntro()
        {
            Console.WriteLine("\nWelcome To Computer Geek Game!\n\nIn this game, your knowledge about Computer Science history is going to be tested. The test cosists of multiple choice and true or false questions. " +
                "Try to get as many correct answers as possible in the least amount of time you can. Good luck!");
        }

        private void PrintMenu()
        {
            Console.WriteLine(
                "\n\n\t\t\t*Main Menu*" +
                "\n\t\tEnter P to start the game" +
                "\n\t\tEnter L to see the Leader Board" +
                "\n\t\tEnter Q to quit the game");
        }

        private char GetUserMenuChoice()
        {
            PrintMenu();

            string userMenuChoice = Console.ReadLine();

            while (!IsUserMenuChoiceValid(userMenuChoice))
            {
                Console.WriteLine("Sorry, the option you entered is not valid. Please try again!");
                PrintMenu();
                userMenuChoice = Console.ReadLine();
            }

            return userMenuChoice[0];
        }

        private bool IsUserMenuChoiceValid(string userMenuChoice)
        {
            if (userMenuChoice == null || userMenuChoice == string.Empty || userMenuChoice.Length > 1)
            {
                return false;
            }

            return UserChoseToPlay(userMenuChoice[0]) || UserChoseToSeeLeaderBoard(userMenuChoice[0]) || UserChoseToQuit(userMenuChoice[0]);
        }

        private bool UserChoseToPlay(char userMenuChoice)
        {
            return userMenuChoice == 'P' || userMenuChoice == 'p';
        }

        private bool UserChoseToSeeLeaderBoard(char userMenuChoice)
        {
            return userMenuChoice == 'L' || userMenuChoice == 'l';
        }

        private bool UserChoseToQuit(char userMenuChoice)
        {
            return userMenuChoice == 'Q' || userMenuChoice == 'q';
        }

        private void Play()
        {
            RandomizeMultipleChoiceQuestions();
            RandomizeTrueOrFalseQuestions();

            // Sort answer options in random order every time call Play()
            foreach(var question in _multipleChoiceQuestions)
            {
                question.RandomizeAnswers();
            }

            int score = 0;
            DateTime startTime = DateTime.Now;

            Console.WriteLine("\n\tLet's Play!\n");            

            for(int i = 0; i < 5; i++)
            {
                _multipleChoiceQuestions[i].PrintQuestion();        
               
                if(_multipleChoiceQuestions[i].IsTheAnswerCorrect(GetMcAnswerFromPlayer()))
                {
                    score++;
                }                

                _trueOrFalseQuestions[i].PrintQuestion();
                
                if(_trueOrFalseQuestions[i].IsTheAnswerCorrect(GetTfAnswerFromUser()))
                {
                    score++;
                }
            }

            DateTime finishTime = DateTime.Now;
            TimeSpan completionTime = finishTime - startTime;

            Console.WriteLine($"\n\tGame Over.\n\tYour score: {score} point(s).\n\tYour time: {completionTime.TotalMinutes} minutes.");

        }

        private void PrintLeaderBoard()
        {
            Console.WriteLine("\n\t|| Leader Board ||\n");

            foreach (var playerScore in _leaderBoard)
            {
                Console.WriteLine($"Name: {playerScore.Name} | Point(s): {playerScore.Points} | Time: {playerScore.Time}\n");
            }
        }

        private void RandomizeMultipleChoiceQuestions()
        {
            List<MultipleChoiceQuestion> tempQuestionList = new List<MultipleChoiceQuestion>();
            Random random = new Random();

            tempQuestionList.AddRange(_multipleChoiceQuestions);
            _multipleChoiceQuestions.Clear();

            while (tempQuestionList.Count > 0)
            {
                int randomIndex = random.Next(0, tempQuestionList.Count - 1);

                _multipleChoiceQuestions.Add(tempQuestionList[randomIndex]);
                tempQuestionList.Remove(tempQuestionList[randomIndex]);
            }            
        }

        private void RandomizeTrueOrFalseQuestions()
        {
            List<TrueOrFalseQuestion> tempQuestionList = new List<TrueOrFalseQuestion>();
            Random random = new Random();

            tempQuestionList.AddRange(_trueOrFalseQuestions);
            _trueOrFalseQuestions.Clear();

            while (tempQuestionList.Count > 0)
            {
                int randomIndex = random.Next(0, tempQuestionList.Count - 1);

                _trueOrFalseQuestions.Add(tempQuestionList[randomIndex]);
                tempQuestionList.Remove(tempQuestionList[randomIndex]);
            }            
        }

        private MultipleChoiceQuestion.Answers GetMcAnswerFromPlayer()
        {               

            while (true)
            {
                Console.Write("\n\tAnswer: ");
                string answerStg = Console.ReadLine();

                if(answerStg.Length < 1 || string.IsNullOrWhiteSpace(answerStg))
                {
                    Console.WriteLine("Please make sure you enter a valid answer.");
                    Console.Write("\n\tAnswer: ");
                    answerStg = Console.ReadLine();
                }

                char answerChar = char.ToUpper(answerStg[0]);

                if (answerChar == 'A')
                    return MultipleChoiceQuestion.Answers.A;

                else if (answerChar == 'B')
                    return MultipleChoiceQuestion.Answers.B;

                else if (answerChar == 'C')
                    return MultipleChoiceQuestion.Answers.C;

                else if (answerChar == 'D')
                    return MultipleChoiceQuestion.Answers.D;                
            }

            
        }

        private bool GetTfAnswerFromUser()
        {          
            while (true) 
            {
                Console.Write("\n\tAnswer: ");
                string answerStg = Console.ReadLine();


                if (answerStg.Length < 1 || string.IsNullOrWhiteSpace(answerStg))
                {
                    Console.WriteLine("Please make sure you enter a valid answer.");
                    Console.Write("\n\tAnswer: ");
                    answerStg = Console.ReadLine();
                }

                char answerChar = char.ToUpper(answerStg[0]);

                if (answerChar == 'T')
                    return true;

                else if (answerChar == 'F')
                    return false;
            }                 
        }        
    }
}
