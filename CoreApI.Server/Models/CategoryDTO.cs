using System.ComponentModel.DataAnnotations;

namespace CoreApI.Server.Models
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string CategoryDesc { get; set; }
    }
}
