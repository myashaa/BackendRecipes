using System;
using System.Collections.Generic;

namespace BackendRecipes.Domain.Abstractions
{
    public interface IRepository<T> where T : class
    {
        void Add( T item );
        void AddRange( IEnumerable<T> items );
        void Delete( T id );
    }
}
