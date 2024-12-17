using Busniess.Factories;
using Busniess.Services;
using Busniess.Interfaces;
using Busniess.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation_Console_MainApp.Dialog;
using Presentation_Console_MainApp.Interfaces;
using Presentation_Console_MainApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var host = Host.CreateDefaultBuilder()
  .ConfigureAppConfiguration((context, config) =>
  {
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
  })

  .ConfigureServices((context, service) =>
  {
    service.Configure<FileServiceOptions>(context.Configuration.GetSection("FileServiceOptions"));
    service.AddScoped<IFileServices>(provider =>
    {
      var fileHandler = provider.GetRequiredService<IFileHandler>();
      var serializer = provider.GetRequiredService<ISerializerService>();
      var options = provider.GetRequiredService<IOptions<FileServiceOptions>>().Value;

      return new FileServices(options.DirectoryPath, options.FileName, fileHandler, serializer);
    });
    service.AddScoped<IDialog, Dialog>();
    service.AddScoped<MenuDialog>();
    service.AddScoped<ISerializerService, SerializerService>();
    service.AddScoped<IFileHandler, FileHandler>();
    service.AddScoped<IUserFactory, UserFactory>();
    service.AddScoped<IUserModel, UserModel>();
    service.AddScoped<IUserInputService, UserInputService>();
  }).Build();

using (var scope = host.Services.CreateScope())
{
  var menuDialog = scope.ServiceProvider.GetRequiredService<MenuDialog>();
  menuDialog.MainMenu();
};


