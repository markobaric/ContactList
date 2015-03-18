using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Phone : ModelBase
    {
        public string Number { get; set; }
        public EntryType Type { get; set; }
        public long ContactId { get; set; }
    }
}
