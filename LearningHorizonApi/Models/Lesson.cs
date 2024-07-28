using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningHorizonApi.Models
{
    public class Lesson
    {
        [Key]
        public int lessonId { get; set; }
        public string lessonTitle { get; set; } = string.Empty;
        public int lessonOrderInCourse { get; set; }
        public int lessonDuration { get; set; }
        public string lessonPath { get; set; } = string.Empty;
        public string lessonLink { get; set; } = string.Empty;
        [ForeignKey("Course")]
        public int courseId { get; set; }
        public Course Course { get; set; }
    }
}
