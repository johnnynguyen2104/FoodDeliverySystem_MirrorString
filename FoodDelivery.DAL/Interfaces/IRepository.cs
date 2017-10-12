using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.DAL.DomainModels;

namespace FoodDelivery.DAL.Interfaces
{
    public interface IRepository<TEntity>where TEntity : class 
    {
        TEntity Create(TEntity entity);

        IQueryable<TEntity> Read(Expression<Func<TEntity, bool>> expression);

        TEntity ReadOne(Expression<Func<TEntity, bool>> expression);

        bool Update(TEntity entity);

        bool Delete(Expression<Func<TEntity, bool>> expression);

        bool Delete(TEntity entity);

        void UpdateValues(TEntity entity, string propertyName, string value);
    }
}
