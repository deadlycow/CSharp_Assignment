using Busniess.Factories;
using Busniess.Interfaces;
using Busniess.Models;
using Busniess.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Presentation_Maui_MainApp.Pages;
using Presentation_Maui_MainApp.ViewModels;

namespace Presentation_Maui_MainApp
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();
      builder
        .UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
          fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });

      builder.Services.AddSingleton<ListAllContacts_Page>();
      builder.Services.AddSingleton<ListAllContactsViewModel>();
      builder.Services.AddSingleton<AddNewContact_Page>();
      builder.Services.AddSingleton<AddNewContactViewModel>();

      builder.Services.AddSingleton<IUserModel, UserModel>();
      builder.Services.AddScoped<ISerializerService, SerializerService>();
      builder.Services.AddScoped<IFileHandler, FileHandler>();
      builder.Services.AddScoped<IUserFactory, UserFactory>();
      builder.Services.AddScoped<IFileServices>(provider =>
      {
        var fileHandler = provider.GetRequiredService<IFileHandler>();
        var serializer = provider.GetRequiredService<ISerializerService>();
        //var options = provider.GetRequiredService<IOptions<FileServiceOptions>>().Value;

        return new FileServices("Data", "users.json", fileHandler, serializer);
      });

#if DEBUG
      builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}
