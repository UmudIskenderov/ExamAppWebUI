using ExamAppDataAccess.Interfaces;
using ExamAppEntities.Implementations;
using ExamAppWebUI.Mappers.Interfaces;
using ExamAppWebUI.Models.Implementations;
using ExamAppWebUI.Services.Interfaces;
using System.Numerics;

namespace ExamAppWebUI.Services.Implementations
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _db;
        private readonly IBaseMapper<Exam, ExamModel> _examMapper;
        public ExamService(IUnitOfWork db, IBaseMapper<Exam, ExamModel> mapper)
        {
            _db = db;
            _examMapper = mapper;
        }

        public bool Delete(ExamModel model)
        {
            var exam = _examMapper.Map(model);
            return _db.ExamRepository.Delete(exam);
        }

        public List<ExamModel> GetAll()
        {
            List<ExamModel> examModels = new List<ExamModel>();
            List<Exam> exams = _db.ExamRepository.GetAll();
            int no = 1;
            foreach (Exam exam in exams)
            {
                ExamModel examModel = _examMapper.Map(exam);
                examModel.No = no++;
                examModels.Add(examModel);
            }
            return examModels;
        }

        public ExamModel? GetById(int id)
        {
            Exam? exam = _db.ExamRepository.Get(x=>x.Id == id);
            if (exam == null)
                return null;
            return _examMapper.Map(exam);
        }

        public ExamModel? GetDuration(int id)
        {
            Exam? exam = _db.ExamRepository.Get(x=>x.Id == id);
            if (exam == null)
                return null;
            return _examMapper.Map(exam);
        }

        public int Save(ExamModel model)
        {
            Exam toBeSavedExam = _examMapper.Map(model);
            if (toBeSavedExam.Id == 0)
            {
                return _db.ExamRepository.Insert(toBeSavedExam);
            }
            else
            {
                Exam? existingExam = _db.ExamRepository.Get(x=>x.Id == model.Id);
                if (existingExam == null) 
                    return 0;
                _db.ExamRepository.Update(toBeSavedExam);
                return toBeSavedExam.Id;
            }
        }
    }
}
