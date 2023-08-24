using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(0, 999.99, ErrorMessage = "Price can't exceed 1000")]
        public decimal Price { get; set; }

        [StringLength(10)]
        public string? Category { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string? Author { get; set; }
    }
}
