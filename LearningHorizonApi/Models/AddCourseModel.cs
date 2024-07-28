namespace LearningHorizonApi.Models
{
    public class AddCourseModel
    {
        public string courseTittle { get; set; } = string.Empty;
        public string courseCreator { get; set; } = string.Empty;
        public decimal coursePrice { get; set; }
    }
}
