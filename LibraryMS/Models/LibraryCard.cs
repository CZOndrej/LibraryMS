using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Models
{
    public class LibraryCard
    {
        [Key]
        public int Barcode { get; set; }
        public DateTime IssuedAt { get; set; }
        public bool IsActive { get; set; }

        public Account Account { get; set; }
        [ForeignKey("Account")]
        public string AccountId { get; set; }


    }
}
