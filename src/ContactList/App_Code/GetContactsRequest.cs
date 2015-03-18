using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactList
{
    public class GetContactsRequest
    {
        public string Search { get; set; }
        public string Sort { get; set; }
        public bool Desc { get; set; }
    }
}