using System;
using System.Collections.Generic;
using System.IO;

public class DeveloperGameClass
{
    private string _scoreBoardfile = "DeveloperGameLeaderBoard.txt";
    private List<KeyValuePair<int, string>> _leaderBoard = new List<KeyValuePair<int, string>>();

    public DeveloperGameClass()
    {
        try
        {
            if (File.Exists(_scoreBoardfile))
            {
                ReadScoresFromFile();
            }
            else
            {
                FileStream stream = File.Create(_scoreBoardfile);
                stream.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nSomething went wrong. The following error was generated: {e.Message} Please exit the game and try again.");
        }
    }

    public void Run()
    {
        PrintIntro();

        while (true)
        {
            char userMenuChoice = GetUserMenuChoice();

            if (UserChoseToPlay(userMenuChoice))
            {
                Play();
            }
            if (UserChoseToSeeLeaderBoard(userMenuChoice))
            {
                PrintLeaderBoard();
            }
            if (UserChoseToQuit(userMenuChoice))
            {
                return;
            }
        }
    }

    private void ReadScoresFromFile()
    {
        StreamReader reader = File.OpenText(_scoreBoardfile);

        string line = reader.ReadLine();

        while (line != null)
        {
            string[] scoreAndName = line.Split(' ');

            if (scoreAndName.Length == 2)
            {
                bool isItConvertible = int.TryParse(scoreAndName[0], out int result);

                if (isItConvertible && !string.IsNullOrWhiteSpace(scoreAndName[1]))
                {
                    _leaderBoard.Add(new KeyValuePair<int, string>(result, scoreAndName[1]));
                }
            }

            line = reader.ReadLine();
        }

        reader.Close();
    }

    private void PrintIntro()
    {
        Console.WriteLine("\nWelcome To The Ultimate Developer Game!");
        Console.WriteLine("\nIn this game, your abilities as a developer are going to be tested. The test cosists of multiple choice and true or false questions. " +
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
            Console.WriteLine("Sorry, the option you entered is not valid.Please try again!");
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
        else if (UserChoseToPlay(userMenuChoice[0]) || UserChoseToSeeLeaderBoard(userMenuChoice[0])|| UserChoseToQuit(userMenuChoice[0]))
        {
            return true;
        }
        else // if the user enters any other character 
        {
            return false;
        }
    }

    private bool UserChoseToPlay(char userMenuChoice)
    {
        if (userMenuChoice == 'P' || userMenuChoice == 'p')
        {
            return true;
        }
        return false;
    }

    private bool UserChoseToSeeLeaderBoard(char userMenuChoice)
    {
        if (userMenuChoice == 'L' || userMenuChoice == 'l')
        {
            return true;
        }
        return false;
    }

    private bool UserChoseToQuit(char userMenuChoice)
    {
        if (userMenuChoice == 'Q' || userMenuChoice == 'q')
        {
            return true;
        }

        return false;
    }

    private void Play()
    {
        Console.WriteLine("Playing");
    }

    private void PrintLeaderBoard()
    {
        Console.WriteLine("Leader Board");
    }
}
