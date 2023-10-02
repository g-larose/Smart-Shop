using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smart_Shop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        [Phone]
        public string Phone { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public virtual ICollection<Invoice>? Invoices { get; set; }

    }
}
