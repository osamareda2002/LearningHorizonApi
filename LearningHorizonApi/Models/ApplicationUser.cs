using Microsoft.AspNetCore.Identity;

namespace LearningHorizonApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Country { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string AcademicYear { get; set; } = string.Empty;
        public DateOnly GraduationYear { get; set; }
    }
}
