using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }

        [Required]
		[DisplayName("Category Name")]
        [MaxLength(30)]
		public String Name { get; set; }

        [Required]
        [DisplayName("Category Order")]
        [Range(1, 20, ErrorMessage ="Display Order must be between 1 and 20")]
        public int DisplayOrder { get; set; }
    }
}
