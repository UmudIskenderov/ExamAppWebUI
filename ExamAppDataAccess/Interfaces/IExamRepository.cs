using ExamAppEntities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppDataAccess.Interfaces
{
    public interface IExamRepository : IEntityRepository<Exam>
    {
    }
}
