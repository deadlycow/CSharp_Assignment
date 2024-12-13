using Busniess.Factories;
using Busniess.Services;
using Busniess.Interfaces;
using Busniess.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation_Console_MainApp.Dialog;

var host = Host.CreateDefaultBuilder()
  .ConfigureServices((context, service) =>
  {
    service.AddScoped<IFileServices>(provider =>
    {
      var directoryPath = "Data";
      var fileName = "users.json";

      return new FileServices(directoryPath, fileName);
    });
    service.AddScoped<Dialog>();
    service.AddScoped<MenuDialog>();
    service.AddScoped<IUserFactory, UserFactory>();
    service.AddScoped<IUserModel, UserModel>();
  }).Build();

using (var scope = host.Services.CreateScope())
{
  var menuDialog = scope.ServiceProvider.GetRequiredService<MenuDialog>();
  menuDialog.MainMenu();
};


