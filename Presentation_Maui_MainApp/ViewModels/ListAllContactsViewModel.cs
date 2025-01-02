using Busniess.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Presentation_Maui_MainApp.ViewModels;
public partial class ListAllContactsViewModel : ObservableObject
{
  public readonly IFileServices _fileServices;
  public event EventHandler? UserChanged;
  public ListAllContactsViewModel(IFileServices fileServices)
  {
   _fileServices = fileServices;
    Users = new ObservableCollection<IUserModel>(_fileServices.LoadFromFile());

    UserChanged += (sender, e) =>
    {
      Users = new ObservableCollection<IUserModel>(_fileServices.LoadFromFile());
    };
  }

  [ObservableProperty]
  public partial ObservableCollection<IUserModel> Users { get; set; }

  [RelayCommand]
  public async Task RemoveUser(IUserModel user)
  {
    bool confirm = await Shell.Current.DisplayAlert("Confirm Deletion", $"Are you sure you want to delete {user.FirstName} {user.LastName}", "Yes", "No");
    if (confirm)
    {
      _fileServices.DeleteUser(user);
      UserChanged?.Invoke(this, EventArgs.Empty);
    }
  }
  [RelayCommand]
  private static async Task NavigateToUpdateContact(IUserModel user)
  {
    var parameters = new ShellNavigationQueryParameters
    {
      { "User", user }
    };

    await Shell.Current.GoToAsync("UpdateContact_Page", parameters);
  }
  public void TriggerUserChanged()
  {
    UserChanged?.Invoke(this, EventArgs.Empty);
  }
}
