using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Tag : EntityBase
    {
        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Text { get; set; }
        public Contact Contact { get; set; }
        public long ContactId { get; set; }
    }
}
