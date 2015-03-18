using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Repositories;
using BLL.Model;
using AutoMapper;

namespace BLL.Services
{
    public class ContactService : ServiceBase<BLL.Model.Contact, DAL.Entities.Contact>
    {
        public ContactService(IRepository<DAL.Entities.Contact> repository)
            : base(repository)
        {
           
        }

        public override IList<Contact> GetAllWithFilteringSortingAndPaging(string search = null, string sort = null, bool desc = false)
        {
            IQueryable<DAL.Entities.Contact> items = String.IsNullOrEmpty(sort)
                ? _repository.EntitySet.Include("Tags").OrderBy(o => o.LastName)
                : _repository.EntitySet.Include("Tags").OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!String.IsNullOrEmpty(search))
                items = items.Where(i => i.FirstName.Contains(search) || i.LastName.Contains(search) || i.Tags.Where(t => t.Text.Contains(search)).Count() > 0);

            return Mapper.Map<IList<DAL.Entities.Contact>, IList<Contact>>(items.ToList<DAL.Entities.Contact>());
        }
    }
}
