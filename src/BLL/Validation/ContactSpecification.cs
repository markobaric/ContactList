using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Model;
using SpecExpress;

namespace BLL.Validation
{
    public class ContactSpecification : Validates<Contact>
    {
        public ContactSpecification()
        {
            Check(c => c.FirstName).Required().MaxLength(20);
            Check(c => c.LastName).Required().MaxLength(20);
            Check(c => c.Phones).Optional().ForEachSpecification<Phone, PhoneSpecification>();
            Check(c => c.Emails).Optional().ForEachSpecification<Email, EmailSpecification>();
            Check(c => c.Tags).Optional().ForEachSpecification<Tag, TagSpecification>();
        }
    }
}
