using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using Smart_Shop.Commands;
using Smart_Shop.Factories;
using Smart_Shop.Interfaces;
using Smart_Shop.Models;
using Smart_Shop.Views;

namespace Smart_Shop.ViewModels
{
   public class NewJobViewModel : ViewModelBase
   {
       private AppDbContextFactory _dbFactory;
       private INavigator _navigator;
       public ICommand AddCustomerCommand { get; }
       public ICommand CloseModalCommand { get; }
       public ICommand SaveCommand { get; }

       private List<string> _customers;
       public List<string> Customers
       {
           get => _customers;
           set => OnPropertyChanged(ref _customers, value);

       }

       private bool _isOpen;

       public bool IsOpen
       {
           get => _isOpen;
           set => OnPropertyChanged(ref _isOpen, value);
       }

       private Guid _identifier;

       public Guid Identifier
       {
           get => _identifier;
           set => OnPropertyChanged(ref _identifier, value);
       }

       private Customer _customer;

       public Customer Customer
       {
           get => _customer;
           set => OnPropertyChanged(ref _customer, value);
       }

       public NewJobViewModel(AppDbContextFactory dbFactory, INavigator navigator)    
       {
           _dbFactory = dbFactory;
           _navigator = navigator;
           //AddCustomerCommand = new NavigateCommand<NewCustomerViewModel>(_navigator, () => new NewCustomerViewModel());
           AddCustomerCommand = new RelayCommand(AddNewCustomer);
           CloseModalCommand = new RelayCommand(CloseModal);
           Identifier = Guid.NewGuid();
           Customer = new();
           LoadCustomers();
       }

        private void CloseModal()
        {
            Customer.CompanyName = "";
            IsOpen = false;
        }

        private void AddNewCustomer()
        {
            if (IsOpen == true) return;
            IsOpen = true;
        }

        private void LoadCustomers()
       {
           Customers = new List<string>();
           Customers.Add("Choose Customer");
           Customers.Add("Inked Apparel Screen Printing");
           Customers.Add("Choo Choo Lawn Equipment");
       }

       
   }
}
