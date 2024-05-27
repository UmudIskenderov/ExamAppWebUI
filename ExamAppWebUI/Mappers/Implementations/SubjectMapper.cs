using ExamAppEntities.Implementations;
using ExamAppWebUI.Mappers.Interfaces;
using ExamAppWebUI.Models.Implementations;

namespace ExamAppWebUI.Mappers.Implementations
{
    public class SubjectMapper : IBaseMapper<Subject, SubjectModel>
    {
        public SubjectModel Map(Subject entity)
        {
            return new SubjectModel()
            {
                Id = entity.Id,
                Class = entity.Class,
                Name = entity.Name,
                Code = entity.Code,
                TeacherName = entity.TeacherName,
                TeacherSurname = entity.TeacherSurname
            };
        }

        public Subject Map(SubjectModel model)
        {
            return new Subject()
            {
                Id = model.Id,
                Name = model.Name,
                Class = model.Class,
                Code = model.Code,
                TeacherName = model.TeacherName,
                TeacherSurname = model.TeacherSurname
            };
        }
    }
}
