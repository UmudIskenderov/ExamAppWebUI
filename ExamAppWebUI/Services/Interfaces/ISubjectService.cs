using ExamAppWebUI.Models.Implementations;

namespace ExamAppWebUI.Services.Interfaces
{
    public interface ISubjectService
    {
        List<SubjectModel> GetAll();
        SubjectModel? GetById(int id);
        SubjectModel? GetDuration(int id);
        int Save(SubjectModel model);
        bool Delete(SubjectModel model);
    }
}
