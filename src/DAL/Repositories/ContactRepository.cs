using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using DAL.Entities;

namespace DAL.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>
    {
        public override Contact GetById(long id)
        {
            using (var db = new ContactListContext())
            {
                return db.Contacts.Where(c => c.Id == id)
                    .Include(x => x.Phones)
                    .Include(x => x.Emails)
                    .Include(x => x.Tags)
                    .Include(x => x.Phones.Select(y => y.Type))
                    .Include(x => x.Emails.Select(y => y.Type))
                    .FirstOrDefault();
            }
        }
        public override void Update(Contact entity)
        {
            using (var db = new ContactListContext())
            {
                var entityInDatabase = db.Contacts.Where(e => e.Id == entity.Id)
                    .Include(x => x.Phones)
                    .Include(x => x.Emails)
                    .Include(x => x.Tags).FirstOrDefault();

                entityInDatabase.FirstName = entity.FirstName;
                entityInDatabase.LastName = entity.LastName;
                entityInDatabase.Address = entity.Address;

                // NOTE:
                // When updating the contact, delete all of the associated
                // Phones, Emails and Tags and add new ones again.
                // This is not a perfect solution but it's the easiest one to implement for this simple scenario
                db.Phones.RemoveRange(entityInDatabase.Phones);
                db.Emails.RemoveRange(entityInDatabase.Emails);
                db.Tags.RemoveRange(entityInDatabase.Tags);

                ((List<Phone>)entity.Phones).ForEach(p =>
                {
                    entityInDatabase.Phones.Add(new Phone 
                    {
                        ContactId = p.ContactId,
                        Number = p.Number,
                        TypeId = p.TypeId
                    });
                });
                ((List<Email>)entity.Emails).ForEach(e =>
                {
                    entityInDatabase.Emails.Add(new Email 
                    {
                        ContactId = e.ContactId,
                        Address = e.Address,
                        TypeId = e.TypeId
                    });
                });
                ((List<Tag>)entity.Tags).ForEach(t =>
                {
                    entityInDatabase.Tags.Add(new Tag
                    {
                        ContactId = t.ContactId,
                        Text = t.Text
                    });
                });

                db.SaveChanges();
            }
        }
    }
}
