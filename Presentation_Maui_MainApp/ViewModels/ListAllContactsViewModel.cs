using Busniess.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Presentation_Maui_MainApp.ViewModels;
public partial class ListAllContactsViewModel : ObservableObject
{
  public readonly IFileServices _fileService;
  public ListAllContactsViewModel(IFileServices fileServices, IUserModel userModel)
  {
    _userModel = userModel;
    _fileService = fileServices;
    _userModels = new ObservableCollection<IUserModel>(_fileService.LoadFromFile());
  }

  [ObservableProperty]
  private IUserModel _userModel;

  [ObservableProperty]
  private ObservableCollection<IUserModel> _userModels;

}
