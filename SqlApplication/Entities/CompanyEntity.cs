using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SqlApplication.Entities;

[Index(nameof(CompanyName), IsUnique = true)]
public class CompanyEntity
{
    [Key]
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
