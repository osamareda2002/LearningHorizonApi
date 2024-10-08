﻿namespace LearningHorizonApi.Models
{
    public class Course
    {
        public int courseId { get; set; }
        public string courseTittle { get; set; } = string.Empty;
        public string courseCreator { get; set; } = string.Empty;
        public decimal coursePrice { get; set; }
        public ICollection<Lesson> lessons { get; set; }
    }
}
