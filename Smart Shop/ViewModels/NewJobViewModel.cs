using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Shop.Factories;

namespace Smart_Shop.ViewModels
{
   public class NewJobViewModel : ViewModelBase
   {
       private AppDbContextFactory _dbFactory;

       public NewJobViewModel(AppDbContextFactory dbFactory)
       {
           _dbFactory = dbFactory;
       }

   }
}
