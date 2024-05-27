using ExamAppEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppEntities.Implementations
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public byte Class { get; set; }
        public string? TeacherName { get; set; }
        public string? TeacherSurname { get; set; }
    }
}
