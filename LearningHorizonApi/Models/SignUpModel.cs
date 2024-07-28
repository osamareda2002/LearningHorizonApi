namespace LearningHorizonApi.Models
{
    public class SignUpModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserCountry { get; set; }
        public string UserUniversity { get; set; }
        public string UserMajor { get; set; }
        public string UserAcademicYear { get; set; }
        public DateOnly UserGraduationYear { get; set; }
    }
}
