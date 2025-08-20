using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KpypLr35_3.Models
{
public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = null!;


    public Category? Category { get; set; }

    [Required]
    [Display(Name = "Категория")]
    public int? CategoryId { get; set; }

    [Range(0.01, 100000)]
    public decimal Price { get; set; }
}

}
