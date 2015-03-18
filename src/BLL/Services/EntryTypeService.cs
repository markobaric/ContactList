using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Repositories;

namespace BLL.Services
{
    public class EntryTypeService : ServiceBase<BLL.Model.EntryType, DAL.Entities.EntryType>
    {
        public EntryTypeService(IRepository<DAL.Entities.EntryType> repository)
            : base(repository)
        {

        }
    }
}
