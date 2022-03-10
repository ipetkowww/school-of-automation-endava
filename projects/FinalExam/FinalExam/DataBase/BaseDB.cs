using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DataBase
{
    public sealed class BaseDb<TContext, TEntity> where TContext : DbContext where TEntity : class, new()
    {
        private readonly DbContext _context;

        public BaseDb(string connectionString)
        {
            _context = (TContext) Activator.CreateInstance(
                typeof(TContext),
                new DbContextOptionsBuilder<TContext>().UseMySql(connectionString).Options);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }
    }
}