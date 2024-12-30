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
    
  }
  [ObservableProperty]
  public partial ObservableCollection<IUserModel> Users { get; set; }
  
  [RelayCommand]
  public void RemoveUser(IUserModel user)
  {
    Users.Remove(user);
    _fileService.DeleteUser(user);
  }
  public void UpdateList()
  {
    Users = new ObservableCollection<IUserModel>(_fileService.LoadFromFile());
  }
}
