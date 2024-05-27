using ExamAppWebUI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ExamAppWebUI.Models.Implementations
{
    public class SubjectModel : IModel
    {
        public int Id { get; set; }
        public int No { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(3, ErrorMessage = "Code must be between 1 and 3 characters")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name must be less than 30 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name must contain only alphabetic characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Class is required")]
        [Range(1, 11, ErrorMessage = "Class must be between 1 and 11")]
        public byte Class { get; set; }

        [Required(ErrorMessage = "Teacher name is required")]
        [StringLength(30, ErrorMessage = "Teacher name must be less than 30 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Teacher name must contain only alphabetic characters")]
        public string? TeacherName { get; set; }

        [Required(ErrorMessage = "Teacher surname is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Teacher surname must be between 3 and 30 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Teacher surname must contain only alphabetic characters")]
        public string? TeacherSurname { get; set; }        
    }
}
