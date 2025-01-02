using Busniess.Interfaces;
using Busniess.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Presentation_Maui_MainApp.ViewModels;
public partial class AddNewContactViewModel(IFileServices fileServices, IUserFactory userFactory, ListAllContactsViewModel listAllContactsViewModel) : ObservableObject
{
  private readonly ListAllContactsViewModel _listAllContactsViewModel = listAllContactsViewModel;
  private readonly IFileServices _fileServices = fileServices;
  private readonly IUserFactory _userFactory = userFactory;

  [ObservableProperty]
  public partial IUserModel UserForm { get; set; } = userFactory.Create();

  [RelayCommand]
  public async Task AddNewUser()
  {
    UserForm.Id = IdGenerator.GenerateId();

    bool success = _fileServices.SaveToFile(UserForm);
    _listAllContactsViewModel.TriggerUserChanged();

    if (success)
    {
      await Shell.Current.DisplayAlert("Contact Created", $"The contact {UserForm.FirstName} {UserForm.LastName} has been successfully created.", "OK");
      UserForm = _userFactory.Create();
    }
  }
}
