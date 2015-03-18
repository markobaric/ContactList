using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using DAL.Entities;

namespace DAL.Repositories
{
    /// <summary>
    /// Interface that defines the contract for all repostories
    /// </summary>
    /// <typeparam name="T">Entity class</typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        DbSet<T> EntitySet { get; }

        IList<T> GetAll();
        T GetById(long id);
        long Insert(T entity);
        void Update(T entity);
        void DeleteById(long id);
    }
}
