using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Repositories;

namespace BLL.Services
{
    public class TagService : ServiceBase<BLL.Model.Tag, DAL.Entities.Tag>
    {
        public TagService(IRepository<DAL.Entities.Tag> repository)
            : base(repository)
        {

        }
    }
}
