using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smart_Shop.ViewModels;
using System.Windows;
using Smart_Shop.Factories;
using Smart_Shop.Interfaces;
using Smart_Shop.Navigation;


namespace Smart_Shop
{
    /// <summary>
    /// This is created by the template
    /// make changes as needed
    /// Author: Async(void)
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<AppViewModel>();
                services.AddSingleton<AppDbContextFactory>();
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
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
