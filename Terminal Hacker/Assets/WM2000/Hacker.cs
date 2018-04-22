using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    int level;
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


    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (currentScreen == Screen.MainMenu)
        {

        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else if (input == "007")
        {
            ShowMainMenu("Welcome back, Agent Bond.");
        }
        else
        {
            print("Invalid input");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level: " + level);
        Terminal.WriteLine("Please enter your password: ");
    }
}
