using Presentation_Maui_MainApp.ViewModels;

namespace Presentation_Maui_MainApp.Pages;

public partial class AddNewContact_Page : ContentPage
{
	public AddNewContact_Page(AddNewContactViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

  private async void Btn_Back_Clicked(object sender, EventArgs e)
  {
		await Shell.Current.GoToAsync("..");
  }
}