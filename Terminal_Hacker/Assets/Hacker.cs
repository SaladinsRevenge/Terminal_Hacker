using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    ShowMainMenu();
  }
  void ShowMainMenu()
  {
    Terminal.ClearScreen();
    Terminal.WriteLine("Initializing hack...");
    Terminal.WriteLine("Press 1 for local Mom & Pop Shop");
    Terminal.WriteLine("Press 2 for Amazon warehouse");
    Terminal.WriteLine("Press 3 for CIA HQ");
    Terminal.WriteLine("After choosing, press Enter");
  }
  int level;
  enum Screen { MainMenu, Password, Win }
  Screen currentScreen = Screen.MainMenu;
  void OnUserInput(string input)
  {
    if (input == "menu")
    {
      ShowMainMenu();
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
    else if (input == "2")
    {
      level = 2;
      StartGame();
    }
    else if (input == "007")
    {
      Terminal.WriteLine("Welcome back, James Bond!");
    }
    else
    {
      Terminal.WriteLine("Enter a valid choice, n00b");
    }
  }

  void StartGame()
  {
    currentScreen = Screen.Password;
    Terminal.WriteLine("You have chosen level " + level);
    Terminal.WriteLine("Enter password...");
  }

  // Update is called once per frame
  void Update()
  {

  }
}
