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
        GetUserMenuChoice();
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
            "\n\n\t\t*Main Menu*" +
            "\n\t\tEnter P to start the game" +
            "\n\t\tEnter L to see the Leader Board" +
            "\n\t\tEnter Q to quit the game");
    }

    private string GetUserMenuChoice()
    {
        PrintMenu();

        string userMenuChoice = Console.ReadLine();

        while (!IsUserMenuChoiceValid(userMenuChoice))
        {
            Console.WriteLine("Sorry, the option you entered is not valid.Please try again!");
            PrintMenu();
            userMenuChoice = Console.ReadLine();
        }
    }

    private bool IsUserMenuChoiceValid(string userMenuChoice)
    {
        if (userMenuChoice == null || userMenuChoice == string.Empty || userMenuChoice.length > 1)
        {
            return false;
        }
        else if (userMenuChoice[0] == char.ToUpper('p') || userMenuChoice[0] == char.ToUpper('l') || userMenuChoice[0] == char.ToUpper('q')) ;
        {
            return true;
        }

        return false;
    }
}
