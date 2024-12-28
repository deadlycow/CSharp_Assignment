using Busniess.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Presentation_Maui_MainApp.ViewModels;
public partial class ListAllContactsViewModel : ObservableObject
{
  public readonly IFileServices _fileService;
  public ListAllContactsViewModel(IFileServices fileServices)
  {
    _fileService = fileServices;
    UserModels = new ObservableCollection<IUserModel>(_fileService.LoadFromFile());
  }
  [ObservableProperty]
  private ObservableCollection<IUserModel> _userModels;

  [RelayCommand]
  public void RemoveUser(IUserModel user)
  {
    UserModels.Remove(user);

    var userList = UserModels.ToList();
    var updateSuccess = _fileService.UpdateFile(userList);
    if (!updateSuccess)
    {
      throw new InvalidOperationException("Failed to update the file.");
    }
  }
}
