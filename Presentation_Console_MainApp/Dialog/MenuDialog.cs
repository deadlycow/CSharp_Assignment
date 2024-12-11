using Busniess.Interfaces;
using Presentation_Console_MainApp.Interfaces;

namespace Presentation_Console_MainApp.Dialog;
public class MenuDialog(Dialog dialog, IFileServices fileServices) : IMenuDialog
{
  private readonly Dialog _dialog = dialog;
  private readonly IFileServices _fileServices = fileServices;

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
      var userChoice = Dialog.PromptUserMenuChoice();
      OptionMenu(userChoice);
    }
  }
  public void AddMenu()
  {
    List<IUserModel> users = [];
    do
    {
      Console.Clear();
      Console.WriteLine($"{"",3}Add new contact.");

      var user = _dialog.GatherUserDetails();
      users.Add(user);

      Console.WriteLine("Contact added successfully.");
    } while (Dialog.PromptForAdditinalUsers());

    if (users.Count > 1)
      Console.WriteLine("All contacts saved successfully.");
    else
      Console.WriteLine("Contact saved successfully.");

    _fileServices.SaveToFile(users);
    Dialog.PromptAnyKeyToContinue();
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
    Dialog.PromptAnyKeyToContinue();
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
        Dialog.PromptAnyKeyToContinue();
        break;
    }
  }
}
