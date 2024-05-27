using ExamAppDataAccess.Extensions;
using ExamAppDataAccess.Interfaces;
using ExamAppEntities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppDataAccess.Implementations.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
    {
        private readonly string _connectionString;
        public EfEntityRepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insert(TEntity entity)
        {
            using (ExamAppContext context = new ExamAppContext(_connectionString))
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public bool Update(TEntity entity)
        {
            using (ExamAppContext context = new ExamAppContext(_connectionString))
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                return context.SaveChanges() != 0 ? true : false;
            }
        }

        public bool Delete(TEntity entity)
        {
            using (ExamAppContext context = new ExamAppContext(_connectionString))
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                return context.SaveChanges() != 0 ? true : false;
            }
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            using (ExamAppContext context = new ExamAppContext(_connectionString))
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (ExamAppContext context = new ExamAppContext(_connectionString))
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public int GetNextId()
        {
            using (ExamAppContext context = new ExamAppContext(_connectionString))
            {
                var result = context.Set<TEntity>().ToList()
                    .Select(t => t.GetType().GetProperties()[0]
                    .GetValue(t)).LastOrDefault() as int?;

                //var obj = context.Set<TEntity>().LastOrDefault().GetType().GetProperties()[0];
                //var temp = obj.GetValue(obj) as int?;

                return result + 1 ?? 1;
            }
        }

        public void DeleteAll()
        {
            using (ExamAppContext context = new ExamAppContext(_connectionString))
            {
                context.Set<TEntity>().Clear();
                context.SaveChanges();
            }
        }
    }
}
