﻿using BackendRecipes.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendRecipes.Infrastructure.Repositories
{
    public class MemoryRepository<T> : IRepository<T> where T : class
    {
        protected static List<T> _table = new List<T>();

        public void Add( T item )
        {
            _table.Add( item );
        }

        public void AddRange( IEnumerable<T> items )
        {
            throw new NotImplementedException();
        }

        public void Delete( int id )
        {
            //_table.Remove( id );
        }

        public void Delete( T id )
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find( Func<T, bool> predicate )
        {
            return _table.Where( predicate );
        }

        public T Get( int id )
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public void Update( T item )
        {
            throw new NotImplementedException();
        }
    }
}
