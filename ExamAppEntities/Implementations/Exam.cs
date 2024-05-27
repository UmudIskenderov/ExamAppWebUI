using ExamAppEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppEntities.Implementations
{
    public class Exam : IEntity
    {
        public int Id { get; set; }
        public string? SubjectCode { get; set; }
        public int StudentNumber { get; set; }
        public DateTime Date { get; set; }
        public byte Grade { get; set; }
    }
}
