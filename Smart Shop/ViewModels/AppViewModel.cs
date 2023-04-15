using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Smart_Shop.Commands;

namespace Smart_Shop.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        public ICommand ExitApplicationCommand { get; }

        public AppViewModel()
        {
            ExitApplicationCommand = new RelayCommand(ExitApp);
        }

        private void ExitApp()
        {
            Environment.Exit(0);
        }
    }
}
