using Busniess.Interfaces;
using Busniess.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Presentation_Maui_MainApp.ViewModels;
public partial class AddNewContactViewModel(IFileServices fileServices, IUserFactory userFactory) : ObservableObject
{
  private readonly IFileServices _fileServices = fileServices;
  private readonly IUserFactory _userFactory = userFactory;

  [ObservableProperty]
  public partial IUserModel UserForm { get; set; } = userFactory.Create();

  [RelayCommand]
  public async Task AddNewUser()
  {
    UserForm.Id = IdGenerator.GenerateId();
    _fileServices.SaveToFile(UserForm);

    UserForm = _userFactory.Create();
    await Shell.Current.GoToAsync("..");
  }
}
