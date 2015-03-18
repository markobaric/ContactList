using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Model;
using SpecExpress;

namespace BLL.Validation
{
    public class PhoneSpecification : Validates<Phone>
    {
        public PhoneSpecification()
        {
            Check(p => p.Number).Required().MaxLength(20);
        }
    }
}
