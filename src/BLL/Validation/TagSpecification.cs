using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Model;
using SpecExpress;

namespace BLL.Validation
{
    public class TagSpecification : Validates<Tag>
    {
        public TagSpecification()
        {
            Check(t => t.Text).Required().MaxLength(20);
        }
    }
}
