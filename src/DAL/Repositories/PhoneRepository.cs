using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using DAL.Entities;

namespace DAL.Repositories
{
    public class PhoneRepository : RepositoryBase<Phone>
    {
        public override IList<Phone> GetAll()
        {
            using (var db = new ContactListContext())
            {
                return db.Phones.Include(x => x.Type).OrderBy(p => p.Id).ToList();
            }
        }
    }
}
