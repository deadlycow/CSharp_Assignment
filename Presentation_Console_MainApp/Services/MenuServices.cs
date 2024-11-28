using Busniess.Factories;
using Busniess.Model;
using Busniess.Services;

namespace Presentation_Console_MainApp.Services
{
  public class MenuServices
  {
    private readonly string[] menuOptions = ["1. Create new contact", "2. List contacts (full)", "3. List contacts(compact)", "(Esc) to quit."];
    ListServices<User> listService = new();
    FileServices fileServices = new();

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
        case ConsoleKey.D3:
          ListAllShort();
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
      Console.Clear();
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
        Console.Clear();

        Console.WriteLine($"{"",3}Add new contact.");
        Console.Write("Given name:");
        user.FirstName = Console.ReadLine()!;
        Console.Write("Surname:");
        user.LastName = Console.ReadLine()!;
        Console.Write("Email:");
        user.Email = Console.ReadLine()!;
        Console.Write("Phone number:");
        if ( int.TryParse(Console.ReadLine(), out int value) )
          user.PhoneNumber = value;

        Console.Write("Address:");
        user.Address = Console.ReadLine()!;
        Console.Write("ZIP Code:");
        if ( int.TryParse(Console.ReadLine(), out value) )
          user.Zip = value;

        Console.Write("City:");
        user.City = Console.ReadLine()!;

        fileServices.SaveToFile(listService.CreateList(user));

        Console.Write("\nPress any key to add more... (Y/N)");
        ConsoleKeyInfo _key = Console.ReadKey();
        if ( _key.Key == ConsoleKey.N ) return;

      }

    }
    private void ListAllUsers()
    {
      Console.Clear();
      Console.WriteLine("Contact List (full):");
      listService.GetList().ForEach((user) =>
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
      });
      Console.WriteLine("\nPress any key to return...");
      Console.ReadKey();
    }
    private void ListAllShort()
    {
      Console.Clear();
      
      var users = listService.GetList();

      int idWidth = users.Max(u => u.Id.ToString().Length);
      int nameWidth = users.Max(u => $"{u.FirstName} {u.LastName}".Length);
      int emailWidth = users.Max(u => u.Email.Length);
      int phoneWidth = users.Max(u => u.PhoneNumber.ToString().Length);
      int addressWidth = users.Max(u => $"{u.Address}, {u.Zip} {u.City}".Length);

      Console.WriteLine("Contact List (compact):");
      Console.WriteLine(new string('-', idWidth + nameWidth + emailWidth + phoneWidth + addressWidth + 10));

      Console.WriteLine("{0,-" + idWidth + "} {1,-" + nameWidth + "} {2,-" + emailWidth + "} {3,-" + phoneWidth + "} {4,-" + addressWidth + "}", "ID", "Name", "Email", "Phone", "Address");
      Console.WriteLine(new string('-', idWidth + nameWidth + emailWidth + phoneWidth + addressWidth + 10));

      
      users.ForEach((user) =>
      {
        Console.WriteLine("{0,-" + idWidth + "} {1,-" + nameWidth + "} {2,-" + emailWidth + "} {3,-" + phoneWidth + "} {4,-" + addressWidth + "}",
            user.Id,
            $"{user.FirstName} {user.LastName}",
            user.Email,
            user.PhoneNumber,
            $"{user.Address}, {user.Zip} {user.City}");
      });

      Console.WriteLine(new string('-', idWidth + nameWidth + emailWidth + phoneWidth + addressWidth + 10));
      Console.WriteLine("\nPress any key to return...");
      Console.ReadKey();
    }
    private static void CloseApp() => Environment.Exit(0);
  }
}
