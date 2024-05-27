using ExamAppWebUI.Models.Implementations;

namespace ExamAppWebUI.ViewModels
{
    public class ExamViewModel
    {
        public ExamViewModel()
        {
            Exams = new List<ExamModel>();
        }
        public List<ExamModel> Exams { get; set; }
    }
}
