using Busniess.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Presentation_Maui_MainApp.ViewModels;
public partial class UpdateContactViewModel(IFileServices fileServices) : ObservableObject, IQueryAttributable
{
  private readonly IFileServices _fileServices = fileServices;

  [ObservableProperty]
  public partial IUserModel User { get; set; }
  public void ApplyQueryAttributes(IDictionary<string, object> query)
  {
    User = (query["User"] as IUserModel)!;
  }
  [RelayCommand]
  public void EditUser()
  {
    _fileServices.UpdateUser(User);
  }
}
