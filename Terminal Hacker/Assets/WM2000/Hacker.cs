﻿using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game Configuration
    string[] level1Passwords = { "ball", "beach", "sand", "fish", "sunscreen" };
    string[] level2Passwords = { "bride", "ringboy", "bachelor", "elope", "weddingcake" };
    string[] level3Passwords = { "icehockey", "volleyball", "snowboarding", "prowrestling", "mixedmartialarts" };

    // Game State
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen; 

    // Use this for initialization
	void Start () {
        ShowMainMenu("Greetings Hackerman!");
	}

    void ShowMainMenu(string greeting) {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("");
        Terminal.WriteLine("What would you like to hack today?");
        Terminal.WriteLine("");
        Terminal.WriteLine("1) FBI");
        Terminal.WriteLine("2) NASA");
        Terminal.WriteLine("3) The White House");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection please:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Greetings Hackerman!");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password){
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevlNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevlNumber) {
            level = int.Parse(input);
            StartGame();
        } else if (input == "007") // easter egg
        {
            ShowMainMenu("Welcome back, Agent Bond.");
        } else {
            print("Invalid input");
        }

    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();

        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Error, Invalid level number");
                break;
        }

        Terminal.WriteLine("Enter your password, hint: ");
        Terminal.WriteLine(password.Anagram());
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            Terminal.WriteLine("Wrong Password, try again.");
        }
    }

     void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Password correct! Let's go to the beach!");

                Terminal.WriteLine(@"
         \ | /
        --(_)--
         / | \
");
                break;
            case 2:
                Terminal.WriteLine("Password correct! Have a couple of rings!");

                Terminal.WriteLine(@"
      ,**,
      .\/.
     //  \\-.
     \\_///`\\
      '-\\__//
         '--'
");
                break;
            case 3:
                Terminal.WriteLine("Password correct! What a stud!");

                Terminal.WriteLine(@"
          __O         O__
          \/\         /\/
          |\ \       / /|
         /  | \_ = _/ |  \
        ~   ~         ~   ~

");
                break;
            default:
                Debug.LogError("Error, invalid level reached");
                break;
        }

    }
}
