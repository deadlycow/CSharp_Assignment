using Presentation_Maui_MainApp.ViewModels;

namespace Presentation_Maui_MainApp.Pages;

public partial class UpdateContact_Page : ContentPage
{
  public UpdateContact_Page(UpdateContactViewModel viewModel)
  {
    InitializeComponent();
    BindingContext = viewModel;
  }

  private async void Btn_Back_Clicked(object sender, EventArgs e)
  {
    await Shell.Current.GoToAsync("..");
  }
}