using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using BLL.Model;
using DAL.Repositories;
using DAL.Entities;

using AutoMapper;
using SpecExpress;

namespace BLL.Services
{
    /// <summary>
    /// Base class for all BLL services.
    /// Implements CRUD, but every concrete service can override virtual methods with its own specific implemenation.
    /// </summary>
    /// <typeparam name="TModel">Model class</typeparam>
    /// <typeparam name="TEntity">Entity class</typeparam>
    public abstract class ServiceBase<TModel, TEntity> : IService<TModel, TEntity>
        where TModel : ModelBase
        where TEntity : EntityBase
    {
        protected IRepository<TEntity> _repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual IList<TModel> GetAll()
        {
            return Mapper.Map<IList<TEntity>, IList<TModel>>(_repository.GetAll());
        }
        public virtual IList<TModel> GetAllWithFilteringSortingAndPaging(string search = null, string sort = null, bool desc = false)
        {
            // NOTE: No implementation here, derived class will override with its own implemenatation
            // because searching and sorting with dynamic linq is entity-specific
            return null;
        }
        public virtual TModel GetById(long id)
        {
            return Mapper.Map<TEntity, TModel>(_repository.GetById(id));
        }
        public virtual long Insert(TModel modelToInsert)
        {
            if (!ValidationCatalog.Validate(modelToInsert).IsValid)
                throw new ApplicationException("Validation of object failed!");
            
            TEntity entityToInsert = Mapper.Map<TModel, TEntity>(modelToInsert);
            return _repository.Insert(entityToInsert);
        }
        public virtual void Update(TModel modelToUpdate)
        {
            if (!ValidationCatalog.Validate(modelToUpdate).IsValid)
                throw new ApplicationException("Validation of object failed!");

            TEntity entityToUpdate = Mapper.Map<TModel, TEntity>(modelToUpdate);
            _repository.Update(entityToUpdate);
        }
        public virtual void Delete(long id)
        {
            _repository.DeleteById(id);
        }
    }
}
