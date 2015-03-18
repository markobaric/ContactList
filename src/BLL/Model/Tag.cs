using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Tag : ModelBase
    {
        public string Text { get; set; }
        public long ContactId { get; set; }
    }
}
