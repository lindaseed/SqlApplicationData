using System.ComponentModel.DataAnnotations;

namespace SqlApplication.Entities;

public class CompanyEntity
{
    [Key]
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
