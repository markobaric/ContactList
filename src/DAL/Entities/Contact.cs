using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Contact : EntityBase
    {
        [Index]
        [Column(TypeName="varchar")]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Index]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Index]
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Address { get; set; }
        public IList<Email> Emails { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
