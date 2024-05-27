using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppDataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ISubjectRepository SubjectRepository { get; }
        IStudentRepository StudentRepository { get; }
        IExamRepository ExamRepository { get; }
    }
}
