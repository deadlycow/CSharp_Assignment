using Presentation_Maui_MainApp.Pages;

namespace Presentation_Maui_MainApp
{
  public partial class AppShell : Shell
  {
    public AppShell()
    {
      InitializeComponent();
      
      Routing.RegisterRoute(nameof(AddNewContact_Page), typeof(AddNewContact_Page));
      Routing.RegisterRoute(nameof(ListAllContacts_Page), typeof(ListAllContacts_Page));
    }
  }
}
