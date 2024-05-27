﻿using ExamAppDataAccess.Interfaces;
using ExamAppEntities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppDataAccess.Implementations.EntityFramework
{
    public class EFStudentRepository : EfEntityRepositoryBase<Student>, IStudentRepository
    {
        public EFStudentRepository(string connectionString) : base(connectionString) 
        {
        }
    }

}
