using ExamAppEntities.Implementations;
using ExamAppWebUI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ExamAppWebUI.Models.Implementations
{
    public class ExamModel : IModel
    {
        public int Id { get; set; }
        public int No { get; set; }

        [Required(ErrorMessage = "Subject code is required")]
        [StringLength(3, ErrorMessage = "Subject code must be between 1 and 3 characters")]
        public string? SubjectCode { get; set; }

        [Required(ErrorMessage = "Student number is required")]
        public int StudentNumber { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        [Range(2, 5, ErrorMessage = "Grade must be between 2 and 5")]
        public byte Grade { get; set; }
    }
}
