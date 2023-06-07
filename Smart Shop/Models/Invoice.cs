using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Shop.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public Guid Identifier { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        //Navigation Properties
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
