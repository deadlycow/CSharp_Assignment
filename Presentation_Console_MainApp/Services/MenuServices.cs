using Busniess.Factories;
using Busniess.Model;
using Busniess.Services;

namespace Presentation_Console_MainApp.Services
{
  public class MenuServices
  {
    private readonly string[] menuOptions = ["1. Create new contact", "2. List all contacts", "(Esc) to quit."];
    ListServices<User> listService = new();

    public void Menu()
    {
      while ( true )
      {
        MenuOption(MainMenu());
      }
    }

    private void MenuOption(ConsoleKeyInfo key)
    {
      switch ( key.Key )
      {
        case ConsoleKey.D1:
          AddNewUser();
          break;
        case ConsoleKey.D2:
          ListAllUsers();
          break;
        case ConsoleKey.Escape:
          CloseApp();
          break;
        default:
          Console.WriteLine("Press VALID key! (1,2,Esc)");
          break;
      }
    }
    private ConsoleKeyInfo MainMenu()
    {
      Console.WriteLine($"{"",3}Main Menu");
      Array.ForEach(menuOptions, option => Console.WriteLine(option));
      ConsoleKeyInfo key = Console.ReadKey();
      return key;
    }
    private void AddNewUser()
    {

      while ( true )
      {
        var user = UserFactory.Create();


        Console.WriteLine($"{"",3}Add new contact.");
        Console.Write("Given name:");
        user.FirstName = Console.ReadLine()!;
        Console.Write("Surname:");
        user.LastName = Console.ReadLine()!;
        Console.Write("Email:");
        user.Email = Console.ReadLine()!;
        Console.Write("Phone number:");
        bool _ = int.TryParse(Console.ReadLine(), out int value);
        user.PhoneNumber = value;
        Console.Write("Address:");
        user.Address = Console.ReadLine()!;
        Console.Write("ZIP Code:");
        _ = int.TryParse(Console.ReadLine(), out value);
        user.Zip = value;
        Console.Write("City:");
        user.City = Console.ReadLine()!;


        listService.CreateList(user);
        Console.WriteLine("Add more contacts? (Y/N)");
        ConsoleKeyInfo _key = Console.ReadKey();
        if ( _key.Key == ConsoleKey.N ) return;

      }

    }
    private void ListAllUsers()
    {
      listService.GetList().ForEach((user) =>
      {
        Console.WriteLine(user.Id);
        Console.WriteLine(user.FirstName);
        Console.WriteLine(user.LastName); 
        Console.WriteLine(user.Email);
        Console.WriteLine(user.PhoneNumber);
        Console.WriteLine(user.Address);
        Console.WriteLine(user.Zip);
        Console.WriteLine(user.City);
      });
        Console.ReadKey();
    }

    private static void CloseApp() => Environment.Exit(0);
  }
}
