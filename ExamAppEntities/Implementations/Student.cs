using ExamAppEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppEntities.Implementations
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public byte Class { get; set; }
    }
}
