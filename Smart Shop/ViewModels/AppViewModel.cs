using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Smart_Shop.Commands;
using Smart_Shop.Data;
using Smart_Shop.Factories;
using Smart_Shop.Interfaces;

namespace Smart_Shop.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IDbContextFactory<AppDbContext>  _dbFactory;


        public ViewModelBase? CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand ExitApplicationCommand { get; }
        public ICommand NavigateNewJobCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public ICommand NavigateHomeCommand { get; }

   

        public AppViewModel(INavigator navigator, IDbContextFactory<AppDbContext> dbFactory)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateNewJobCommand = new NavigateCommand<NewJobViewModel>(_navigator, () => new NewJobViewModel(_dbFactory, _navigator));
            NavigateSettingsCommand = new NavigateCommand<SettingsViewModel>(_navigator, () => new SettingsViewModel());
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(_navigator, () => new HomeViewModel(_navigator, _dbFactory));
            ExitApplicationCommand = new RelayCommand(ExitApp);
        }

      

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void ExitApp()
        {
            Environment.Exit(0);
        }
    }
}
