using Busniess.Interfaces;
using Presentation_Console_MainApp.Interfaces;

namespace Presentation_Console_MainApp.Dialog;
public class MenuDialog(IDialog dialog, IFileServices fileServices, IUserInputService userInputService)
{
  private readonly IDialog _dialog = dialog;
  private readonly IFileServices _fileServices = fileServices;
  private readonly IUserInputService _userInputService = userInputService;

  private readonly string[] menuOptions =
    [
    "1. Create new contact",
    "2. List all contacts",
    "(Esc) to exit."
    ];

  public void MainMenu()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine($"{"",3}Main Menu");
      foreach (string menuItem in menuOptions)
      {
        Console.WriteLine(menuItem);
      }
      OptionMenu(_userInputService.UserInputKey());
    }
  }
  public void AddMenu()
  {
    Console.Clear();
    Console.WriteLine($"{"",3}Add new contact.");
    _dialog.GatherUserDetails();
  }
  public void ListAllMenu()
  {
    Console.Clear();
    Console.WriteLine("Contact List :");

    IEnumerable<IUserModel> users = _fileServices.LoadFromFile();
    foreach (IUserModel user in users)
    {
      Console.WriteLine($"ID:           {user.Id}");
      Console.WriteLine($"First Name:   {user.FirstName}");
      Console.WriteLine($"Last Name:    {user.LastName}");
      Console.WriteLine($"Email:        {user.Email}");
      Console.WriteLine($"Phone Number: {user.PhoneNumber}");
      Console.WriteLine($"Address:      {user.Address}");
      Console.WriteLine($"ZIP Code:     {user.Zip}");
      Console.WriteLine($"City:         {user.City}");
      Console.WriteLine(new string('-', 50));
    };
    _userInputService.UserInputContinue();
  }
  public void OptionMenu(ConsoleKey pressedKey)
  {
    switch (pressedKey)
    {
      case ConsoleKey.D1:
        AddMenu();
        break;
      case ConsoleKey.D2:
        ListAllMenu();
        break;
      case ConsoleKey.Escape:
        Environment.Exit(0);
        break;
      default:
        Console.WriteLine("Invalid option!");
        _userInputService.UserInputContinue();
        break;
    }
  }
}
