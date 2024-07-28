namespace LearningHorizonApi.Models
{
    public class AddBookModel
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile ImageFile { get; set; }
        public IFormFile BookFile { get; set; }
        public string BookLink { get; set; } = null!;

    }
}
