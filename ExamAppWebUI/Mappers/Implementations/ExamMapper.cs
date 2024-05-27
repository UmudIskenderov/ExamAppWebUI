using ExamAppEntities.Implementations;
using ExamAppWebUI.Mappers.Interfaces;
using ExamAppWebUI.Models.Implementations;

namespace ExamAppWebUI.Mappers.Implementations
{
    public class ExamMapper : IBaseMapper<Exam, ExamModel>
    {
        public ExamModel Map(Exam entity)
        {
            return new ExamModel()
            {
                Id = entity.Id,
                SubjectCode = entity.SubjectCode,
                StudentNumber = entity.StudentNumber,
                Date = entity.Date,
                Grade = entity.Grade
            };
        }

        public Exam Map(ExamModel model)
        {
            return new Exam()
            {
                Id = model.Id,
                SubjectCode = model.SubjectCode,
                StudentNumber = model.StudentNumber,
                Date = model.Date,
                Grade = model.Grade
            };
        }
    }
}
