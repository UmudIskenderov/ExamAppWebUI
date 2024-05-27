using ExamAppWebUI.Models.Implementations;

namespace ExamAppWebUI.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            Students = new List<StudentModel>();
        }
        public List<StudentModel> Students { get; set; }
    }
}
