namespace StacyStore.Models;

using System.ComponentModel.DataAnnotations;

public class Product {
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public Category Category { get; set; }
}
