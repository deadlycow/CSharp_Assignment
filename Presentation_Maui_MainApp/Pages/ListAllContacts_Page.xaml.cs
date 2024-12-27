using Presentation_Maui_MainApp.ViewModels;

namespace Presentation_Maui_MainApp.Pages;

public partial class ListAllContacts_Page : ContentPage
{
	public ListAllContacts_Page(ListAllContactsViewModel listAllContactsViewModel)
	{
		InitializeComponent();
		BindingContext = listAllContactsViewModel;
	}

  private async void Btn_Back_Clicked(object sender, EventArgs e)
  {
		await Shell.Current.GoToAsync("..");
  }
}