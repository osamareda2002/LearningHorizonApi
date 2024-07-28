using System.ComponentModel.DataAnnotations;

namespace LearningHorizonApi.Models
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }
        public string bookTitle { get; set; } = string.Empty;
        public decimal bookPrice { get; set; } = decimal.Zero;
        public string bookLink { get; set; } = string.Empty;
        public string bookPath { get; set; } = string.Empty;
        public string bookImageLink { get; set; } = string.Empty;
        public string bookDescription { get; set; } = string.Empty;
    }
}
