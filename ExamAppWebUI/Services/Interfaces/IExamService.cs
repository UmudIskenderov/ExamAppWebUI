using ExamAppWebUI.Models.Implementations;

namespace ExamAppWebUI.Services.Interfaces
{
    public interface IExamService
    {
        List<ExamModel> GetAll();
        ExamModel? GetById(int id);
        ExamModel? GetDuration(int id);
        int Save(ExamModel model);
        bool Delete(ExamModel model);
    }
}
