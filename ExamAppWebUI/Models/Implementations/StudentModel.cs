using ExamAppWebUI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ExamAppWebUI.Models.Implementations
{
    public class StudentModel : IModel
    {
        public int Id { get; set; }
        public int No { get; set; }

        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name must contain only alphabetic characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Surname must be between 3 and 30 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Surname must contain only alphabetic characters")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Class is required")]
        [Range(1, 11, ErrorMessage = "Class must be between 1 and 11")]
        public byte Class { get; set; }
    }
}
