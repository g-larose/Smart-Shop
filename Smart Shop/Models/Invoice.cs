using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Shop.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public double Total { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Item>? Items { get; set; }
    }
}
