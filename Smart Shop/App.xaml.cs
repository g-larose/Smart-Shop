using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smart_Shop.ViewModels;
using System.Windows;
using Smart_Shop.Factories;
using Smart_Shop.Interfaces;
using Smart_Shop.Navigation;
using Smart_Shop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;
using System.Text.Json;
using Smart_Shop.Models;

namespace Smart_Shop
{
    public partial class App : Application
    {
        private readonly IHost _host;
       
        public App()
        {
           
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<AppViewModel>();
                services.AddSingleton<SettingsViewModel>();
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<AppDbContextFactory>();
                services.AddDbContextFactory<AppDbContext>();
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<AppViewModel>()
                });
                

            }).Build();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
