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
    /// Base class for all repositories. 
    /// Implements CRUD, but every repository can override virtual methods with its own specific implemenation.
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        public DbSet<T> EntitySet 
        { 
            get { return (new ContactListContext()).Set<T>(); }
        }

        public virtual IList<T> GetAll()
        {
            using (var db = new ContactListContext())
            {
                return db.Set<T>().OrderBy(e => e.Id).ToList();
            }
        }
        public virtual T GetById(long id)
        {
            using (var db = new ContactListContext())
            {
                return db.Set<T>().Where(e => e.Id == id).FirstOrDefault();
            }
        }
        public virtual long Insert(T entity)
        {
            using (var db = new ContactListContext())
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();

                return entity.Id;
            }
        }
        public virtual void Update(T entity)
        {
            using (var db = new ContactListContext())
            {
                var entityInDatabase = db.Set<T>().Where(e => e.Id == entity.Id).FirstOrDefault();

                if (entityInDatabase != null)
                {
                    var id = entity.Id;
                    entity.Id = 0;
                    db.Set<T>().Attach(entity);
                    db.Entry(entity).Entity.Id = 0;
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public virtual void DeleteById(long id)
        {
            using (var db = new ContactListContext())
            {
                var entityInDatabase = db.Set<T>().Where(e => e.Id == id).FirstOrDefault();

                if (entityInDatabase != null)
                {
                    db.Set<T>().Remove(entityInDatabase);
                    db.SaveChanges();
                }
            }
        }
    }
}
