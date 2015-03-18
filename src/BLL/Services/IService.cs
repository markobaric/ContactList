using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Model;
using DAL.Entities;

namespace BLL.Services
{
    /// <summary>
    /// Interface that defines the contract for all services
    /// </summary>
    /// <typeparam name="TModel">Model class</typeparam>
    /// <typeparam name="TEntity">Entity class</typeparam>
    public interface IService<TModel, TEntity>
        where TModel : ModelBase
        where TEntity : EntityBase
    {
        IList<TModel> GetAll();
        IList<TModel> GetAllWithFilteringSortingAndPaging(string search = null, string sort = null, bool desc = false);
        TModel GetById(long id);
        long Insert(TModel modelToInsert);
        void Update(TModel modelToUpdate);
        void Delete(long id);
    }
}
