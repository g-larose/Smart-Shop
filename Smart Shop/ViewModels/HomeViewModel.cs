
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Smart_Shop.Data;
using Smart_Shop.Factories;
using Smart_Shop.Interfaces;
using Smart_Shop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Shop.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private IDbContextFactory<AppDbContext> _dbContext;

		private ObservableCollection<Customer>? _customers;
		public ObservableCollection<Customer>? Customers
		{
			get => _customers;
			set => OnPropertyChanged(ref _customers, value);
		}

        public HomeViewModel(INavigator navigator, IDbContextFactory<AppDbContext> dbFactory)
        {
            _navigator = navigator;
            _dbContext = dbFactory;
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            Customers = new ObservableCollection<Customer>();

            using var db = _dbContext.CreateDbContext();
            foreach (var cust in db.Customers.ToList())
            {
                Customers.Add(cust);
            }
        }
    }
}
