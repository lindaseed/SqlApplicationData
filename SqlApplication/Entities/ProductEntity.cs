using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlApplication.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set;}
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    public int CompanyId { get; set; }
    public CompanyEntity Company { get; set; } = null!;
}
