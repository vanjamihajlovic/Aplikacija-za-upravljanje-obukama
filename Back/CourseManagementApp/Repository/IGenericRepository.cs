﻿using CourseManagementApp.Model;
using System.Linq.Expressions;

namespace CourseManagementApp.Repository
{
    public interface IGenericRepository<T, Key> where T : IEntity<Key>
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Key id, params Expression<Func<T, object>>[] includes);
        Task<T> Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate);
    }
}
