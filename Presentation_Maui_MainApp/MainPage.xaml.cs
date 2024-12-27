namespace Presentation_Maui_MainApp
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
    }

    private async void Btn_AllContacts_Clicked(object sender, EventArgs e)
    {
      await Shell.Current.GoToAsync("ListAllContacts_Page");
    }

    private async void Btn_AddNewContact_Clicked(object sender, EventArgs e)
    {
      await Shell.Current.GoToAsync("AddNewContact_Page");
    }
  }
}
