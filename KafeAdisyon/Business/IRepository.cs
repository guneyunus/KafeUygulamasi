using KafeAdisyon.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using KafeAdisyon.Data.Abstract;

namespace KafeAdisyon.Business
{
    public interface IRepository<T, in TId> where T : BaseEntity// t => entity tid => entity primary key type
    {
        T GetById(TId id);
        IQueryable<T> Get(Func<T, bool> predicate = null);
        void Add(T entity, bool isSaveLater = false);
        void Remove(T entity, bool isSaveLater = false);
        void Update(T entity, bool isSaveLater = false);

        int Save();


    }

}