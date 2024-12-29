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
    Users = new ObservableCollection<IUserModel>(_fileService.LoadFromFile());
  }
  [ObservableProperty]
  public partial ObservableCollection<IUserModel> Users { get; set; }
  
  [RelayCommand]
  public void RemoveUser(IUserModel user)
  {
    Users.Remove(user);

    var userList = Users.ToList();
    var updateSuccess = _fileService.UpdateFile(userList);
    if (!updateSuccess)
    {
      throw new InvalidOperationException("Failed to update the file.");
    }
  }
}
