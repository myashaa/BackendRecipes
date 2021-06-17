using BackendRecipes.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BackendRecipes.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Entities => DbContext.Set<T>();

        private readonly DbContext DbContext;

        public Repository( DbContext dbContext )
        {
            DbContext = dbContext;
        }

        public void Add( T item )
        {
            DbContext.Add( item );
        }

        public void Delete( T item )
        {
            DbContext.Remove( item );
        }

        public void AddRange( IEnumerable<T> entities )
        {
            DbContext.AddRange( entities );
        }
    }
}
