using ExamAppDataAccess.Interfaces;
using ExamAppEntities.Implementations;
using ExamAppWebUI.Mappers.Interfaces;
using ExamAppWebUI.Models.Implementations;
using ExamAppWebUI.Services.Interfaces;
using System.Numerics;

namespace ExamAppWebUI.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _db;
        private readonly IBaseMapper<Student, StudentModel> _studentMapper;
        public StudentService(IUnitOfWork db, IBaseMapper<Student, StudentModel> mapper)
        {
            _db = db;
            _studentMapper = mapper;
        }

        public bool Delete(StudentModel model)
        {
            var student = _studentMapper.Map(model);
            return _db.StudentRepository.Delete(student);
        }

        public List<StudentModel> GetAll()
        {
            List<StudentModel> studentModels = new List<StudentModel>();
            List<Student> students = _db.StudentRepository.GetAll();
            int no = 1;
            foreach (Student student in students)
            {
                StudentModel studentModel = _studentMapper.Map(student);
                studentModel.No = no++;
                studentModels.Add(studentModel);
            }
            return studentModels;
        }

        public StudentModel? GetById(int id)
        {
            Student? student = _db.StudentRepository.Get(x=>x.Id == id);
            if (student == null)
                return null;
            return _studentMapper.Map(student);
        }

        public StudentModel? GetDuration(int id)
        {
            Student? student = _db.StudentRepository.Get(x=>x.Id == id);
            if (student == null)
                return null;
            return _studentMapper.Map(student);
        }

        public int Save(StudentModel model)
        {
            Student toBeSavedStudent = _studentMapper.Map(model);
            if (toBeSavedStudent.Id == 0)
            {
                return _db.StudentRepository.Insert(toBeSavedStudent);
            }
            else
            {
                Student? existingStudent = _db.StudentRepository.Get(x=>x.Id == model.Id);
                if (existingStudent == null) 
                    return 0;
                _db.StudentRepository.Update(toBeSavedStudent);
                return toBeSavedStudent.Id;
            }
        }
    }
}
