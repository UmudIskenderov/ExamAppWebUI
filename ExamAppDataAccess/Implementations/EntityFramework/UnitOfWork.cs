using ExamAppDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppDataAccess.Implementations.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ISubjectRepository SubjectRepository => new EFSubjectRepository(_connectionString);

        public IStudentRepository StudentRepository => new EFStudentRepository(_connectionString);

        IExamRepository IUnitOfWork.ExamRepository => new EFExamRepository(_connectionString);
    }
}
