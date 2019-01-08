using UnityEngine;

public class Hacker : MonoBehaviour
{
  string[] level1Passwords = { "sell", "register", "clerk", "local", "owner" };
  string[] level2Passwords = { "ecommerce", "category", "department", "accounts", "storage" };
  string[] level3Passwords = { "intelligence", "recon", "classified", "langley", "federal" };
  int level;
  string password;
  enum Screen { MainMenu, Password, Win }
  Screen currentScreen = Screen.MainMenu;
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
  void OnUserInput(string input)
  {
    if (input == "menu")
    {
      currentScreen = Screen.MainMenu;
      ShowMainMenu();
    }
    else if (currentScreen == Screen.MainMenu)
    {
      RunMainMenu(input);
    }
    else if (currentScreen == Screen.Password)
    {
      CheckPassword(input);
    }
  }
  void RunMainMenu(string input)
  {
    bool isValidLevel = (input == "1" || input == "2" || input == "3");

    if (isValidLevel)
    {
      level = int.Parse(input);
      AskForPassword();
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
  void AskForPassword()
  {
    currentScreen = Screen.Password;
    Terminal.ClearScreen();
    SetRandomPassword();
    Terminal.WriteLine("Enter password...");
    Terminal.WriteLine("HINT: " + password.Anagram());
  }
  void SetRandomPassword()
  {
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
        Debug.LogError("Invalid level number");
        break;
    }
  }
  void CheckPassword(string input)
  {
    if (input == password)
    {
      DisplayWinScreen();
    }
    else
    {
      AskForPassword();
    }
  }
  void DisplayWinScreen()
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
        Terminal.WriteLine("Five Finger Discount Unlocked!");
        Terminal.WriteLine(@"
──▄▄█▀▀▀▀▀█▄▄──
▄█▀░░▄░▄░░░░▀█▄
█░░░▀█▀▀▀▀▄░░░█
█░░░░█▄▄▄▄▀░░░█
█░░░░█░░░░█░░░█
▀█▄░▀▀█▀█▀░░▄█▀
──▀▀█▄▄▄▄▄█▀▀──
        ");
        break;
      case 2:
        Terminal.WriteLine("Jeff Bezos won't be happy about this...");
        Terminal.WriteLine(@"
¯\_ಠ_ಠ_/¯    
        ");
        break;
      case 3:
        Terminal.WriteLine("J. Edgar Hoover would improve!");
        Terminal.WriteLine(@"
   _
 ( ((
  \ =\
 __\_ `-\ 
(____))(  \----
(____)) _  
(____))
(____))____/----
        ");
        break;
    }
  }
}
