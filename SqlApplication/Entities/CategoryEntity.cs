using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SqlApplication.Entities;

[Index(nameof(CategoryName), IsUnique = true)]
public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

}
