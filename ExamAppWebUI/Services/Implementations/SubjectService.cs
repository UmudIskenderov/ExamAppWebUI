using ExamAppDataAccess.Interfaces;
using ExamAppEntities.Implementations;
using ExamAppWebUI.Mappers.Interfaces;
using ExamAppWebUI.Models.Implementations;
using ExamAppWebUI.Services.Interfaces;
using System.Numerics;

namespace ExamAppWebUI.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _db;
        private readonly IBaseMapper<Subject, SubjectModel> _subjectMapper;
        public SubjectService(IUnitOfWork db, IBaseMapper<Subject, SubjectModel> mapper)
        {
            _db = db;
            _subjectMapper = mapper;
        }

        public bool Delete(SubjectModel model)
        {
            var subject = _subjectMapper.Map(model);
            return _db.SubjectRepository.Delete(subject);
        }

        public List<SubjectModel> GetAll()
        {
            List<SubjectModel> subjectModels = new List<SubjectModel>();
            List<Subject> subjects = _db.SubjectRepository.GetAll();
            int no = 1;
            foreach (Subject subject in subjects)
            {
                SubjectModel subjectModel = _subjectMapper.Map(subject);
                subjectModel.No = no++;
                subjectModels.Add(subjectModel);
            }
            return subjectModels;
        }

        public SubjectModel? GetById(int id)
        {
            Subject? subject = _db.SubjectRepository.Get(x=>x.Id == id);
            if (subject == null)
                return null;
            return _subjectMapper.Map(subject);
        }

        public SubjectModel? GetDuration(int id)
        {
            Subject? subject = _db.SubjectRepository.Get(x=>x.Id == id);
            if (subject == null)
                return null;
            return _subjectMapper.Map(subject);
        }

        public int Save(SubjectModel model)
        {
            Subject toBeSavedSubject = _subjectMapper.Map(model);
            if (toBeSavedSubject.Id == 0)
            {
                return _db.SubjectRepository.Insert(toBeSavedSubject);
            }
            else
            {
                Subject? existingSubject = _db.SubjectRepository.Get(x=>x.Id == model.Id);
                if (existingSubject == null) 
                    return 0;
                _db.SubjectRepository.Update(toBeSavedSubject);
                return toBeSavedSubject.Id;
            }
        }
    }
}
