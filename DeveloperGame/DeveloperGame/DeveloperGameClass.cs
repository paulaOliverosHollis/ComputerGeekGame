using System;

public class DeveloperGameClass
{
    public DeveloperGameClass()
    {
        // To do.
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
