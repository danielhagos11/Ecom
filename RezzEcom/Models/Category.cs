using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RezzEcom.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "The field Display Order must be between (1-100).")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
