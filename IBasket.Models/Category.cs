using System.ComponentModel.DataAnnotations;

namespace IBasket.Models;

    public class Category
    {

    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    [Range(1,50,ErrorMessage ="Range should be 1 to 50 only!")]
    [Display(Name ="Display Order")]
    public int DisplayOrder { get; set; }
}

