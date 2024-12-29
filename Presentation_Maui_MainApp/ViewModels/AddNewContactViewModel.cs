using Busniess.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Presentation_Maui_MainApp.ViewModels;
public partial class AddNewContactViewModel: ObservableObject
{
  private readonly IFileServices _fileServices;
  public AddNewContactViewModel(IFileServices fileServices, IUserModel userModel)
  {
    _fileServices = fileServices;
    UserForm = userModel;
  }

  [ObservableProperty]
  public partial IUserModel UserForm { get; set; }
}
