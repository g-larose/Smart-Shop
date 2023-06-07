using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Shop.ViewModels
{
    public class NewCustomerViewModel : ViewModelBase
    {
		private string customerIdentifier;
		public string CustomerIdentifier
		{
			get => customerIdentifier;
			set => OnPropertyChanged(ref customerIdentifier, value);
		}

        public NewCustomerViewModel()
        {
            CustomerIdentifier = "123456789";
        }
	}
}
