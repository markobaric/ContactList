using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using DAL.Entities;

namespace DAL.Repositories
{
    public class EmailRepository : RepositoryBase<Email>
    {
        public override IList<Email> GetAll()
        {
            using (var db = new ContactListContext())
            {
                return db.Emails.Include(x => x.Type).OrderBy(e => e.Id).ToList();
            }
        }
    }
}
