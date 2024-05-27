using ExamAppWebUI.Models.Implementations;

namespace ExamAppWebUI.Services.Interfaces
{
    public interface IStudentService
    {
        List<StudentModel> GetAll();
        StudentModel? GetById(int id);
        StudentModel? GetDuration(int id);
        int Save(StudentModel model);
        bool Delete(StudentModel model);
    }
}
