using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;

namespace DAL
{
    /// <summary>
    /// Handles initial seeding of empty databases
    /// </summary>
    internal class CustomDbInitializer : CreateDatabaseIfNotExists<ContactListContext>
    {
        protected override void Seed(ContactListContext context)
        {
            context.EntryTypes.Add(new EntryType { Name = "Home" });
            context.EntryTypes.Add(new EntryType { Name = "Mobile" });
            context.EntryTypes.Add(new EntryType { Name = "Work" });
            context.EntryTypes.Add(new EntryType { Name = "Other" });
        }
    }
}
