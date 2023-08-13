using IBasket.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBasket.Models
{
    public class MissingItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public bool Status { get; set; }

        

    }
}
