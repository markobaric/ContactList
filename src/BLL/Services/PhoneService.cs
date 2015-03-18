using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Repositories;

namespace BLL.Services
{
    public class PhoneService : ServiceBase<BLL.Model.Phone, DAL.Entities.Phone>
    {
        public PhoneService(IRepository<DAL.Entities.Phone> repository)
            : base(repository)
        {

        }
    }
}
