using Busniess.Factories;
using Busniess.Services;
using Busniess.Interfaces;
using Busniess.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation_Console_MainApp.Dialog;

var host = Host.CreateDefaultBuilder()
  .ConfigureServices(service =>
  {
    service.AddScoped<IFileServices, FileServices>();
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


