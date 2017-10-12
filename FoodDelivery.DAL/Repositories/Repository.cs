using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.DAL.DomainModels;
using FoodDelivery.DAL.Interfaces;

namespace Mars.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        private readonly IDbContext _dbContext;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Create(TEntity entity)
        {
            return entity == null ? null : _dbContext.Set<TEntity>().Add(entity);
        }

        public bool Delete(TEntity entity)
        {
            if (entity == null) throw  new ArgumentNullException("entity", "Entity can't be null.");
            _dbContext.Entry(entity).State = EntityState.Deleted;
            return true;
        }

        public void UpdateValues(TEntity entity, string propertyName, string value)
        {
            Type sourceType = typeof(TEntity);
            var properties = sourceType.GetProperties();
            foreach (PropertyInfo propInfo in properties)
            {
                if (propInfo.Name == propertyName)
                {
                    propInfo.SetValue(entity, ChangeType<int?>(value), null);
                    return;
                }
            }
        }

        public bool Delete(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
            {
                throw  new ArgumentNullException("expression", "Expression can't be Null.");
            }

            var deletedList = _dbContext.Set<TEntity>().Where(expression).ToList();

            foreach (var item in deletedList)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
            }
            return true;
        }

        public IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }

        public TEntity ReadOne(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(expression);
        }

        public bool Update(TEntity entity)
        {
            if (entity == null)
            {
                throw  new ArgumentNullException("entity", "Entity can't be null");
            }

            _dbContext.Entry(entity).State = EntityState.Modified;

            return true;
        }

        private T ChangeType<T>(object value)
        {
            var t = typeof(T);

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                {
                    return default(T);
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return (T)Convert.ChangeType(value, t);
        }
    }
}
