using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Contact : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public IList<Email> Emails { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
