using System.ComponentModel.DataAnnotations;

namespace Smart_Shop.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Identifier { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public double? Price { get; set; }
        public Category? Category { get; set; }
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
    }
}