using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Model;
using SpecExpress;

namespace BLL.Validation
{
    public class EmailSpecification : Validates<Email>
    {
        private const string EMAIL_REGEX = @"[\w-]+@([\w-]+\.)+[\w-]+";

        public EmailSpecification()
        {
            Check(e => e.Address).Required().MaxLength(50).And.Matches(EMAIL_REGEX);
        }
    }
}
