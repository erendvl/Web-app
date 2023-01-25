using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(0,150,ErrorMessage ="Display order should be between 0 and 150"!)]
        public int DisplayOrder { get; set; }

        
        public DateTime CreatedDate { get; set; }=DateTime.Now;

    }
}
