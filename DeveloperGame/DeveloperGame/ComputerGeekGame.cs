using System;

public class ComputerGeekGame
{
    public ComputerGeekGame()
    {
        // To do.
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
            else if(UserChoseToSeeLeaderBoard(userMenuChoice))
            {
                PrintLeaderBoard();
            }
           
        } while (!UserChoseToQuit(userMenuChoice));
    }

    private void PrintIntro()
    {
        Console.WriteLine("\nWelcome To Computer Geek Game!");
        Console.WriteLine("\nIn this game, your knowledge about Computer Science history is going to be tested. The test cosists of multiple choice and true or false questions. " +
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
        Console.WriteLine("Playing");
    }

    private void PrintLeaderBoard()
    {
        Console.WriteLine("Leader Board");
    }
}
