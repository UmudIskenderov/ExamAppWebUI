using ExamAppWebUI.Models.Implementations;

namespace ExamAppWebUI.ViewModels
{
    public class SubjectViewModel
    {
        public SubjectViewModel()
        {
            Subjects = new List<SubjectModel>();
        }
        public List<SubjectModel> Subjects { get; set; }
    }
}
