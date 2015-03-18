using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Repositories;

namespace BLL.Services
{
    public class EmailService : ServiceBase<BLL.Model.Email, DAL.Entities.Email>
    {
        public EmailService(IRepository<DAL.Entities.Email> repository)
            : base(repository)
        {

        }
    }
}
