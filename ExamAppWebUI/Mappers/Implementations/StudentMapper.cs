using ExamAppEntities.Implementations;
using ExamAppWebUI.Mappers.Interfaces;
using ExamAppWebUI.Models.Implementations;

namespace ExamAppWebUI.Mappers.Implementations
{
    public class StudentMapper : IBaseMapper<Student, StudentModel>
    {
        public StudentModel Map(Student entity)
        {
            return new StudentModel()
            {
                Id = entity.Id,
                Class = entity.Class,
                Number = entity.Number,
                Surname = entity.Surname,
                Name = entity.Name,
            };
        }

        public Student Map(StudentModel model)
        {
            return new Student()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Number = model.Number,
                Class = model.Class,
            };
        }
    }
}
