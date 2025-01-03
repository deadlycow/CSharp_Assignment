using Busniess.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Presentation_Maui_MainApp.ViewModels;
public partial class UpdateContactViewModel(IFileServices fileServices, IUserFactory userFactory, ListAllContactsViewModel listAllContactsViewModel) : ObservableObject, IQueryAttributable
{
  private readonly IUserFactory _userFactory = userFactory;
  private readonly IFileServices _fileServices = fileServices;
  private readonly ListAllContactsViewModel _listAllContactsViewModel = listAllContactsViewModel;

  [ObservableProperty]
  public partial IUserModel User { get; set; }
  public void ApplyQueryAttributes(IDictionary<string, object> query)
  {
    User = (query["User"] as IUserModel)!;
  }
  [RelayCommand]
  public async Task EditUser()
  {
    bool success = _fileServices.UpdateUser(User);
    if (success)
    {
      await Shell.Current.DisplayAlert("Contact Updated", $"{User.FirstName} {User.LastName} has been updated successfully.", "OK");
      _listAllContactsViewModel.TriggerUserChanged();
      User = _userFactory.Create();
      await Shell.Current.GoToAsync("..");
    }
  }
}
