using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Models
{
    public class BookItem: Book
    {
        public int Barcode { get; set; }
        public DateTime Borrowed { get; set; }
        public DateTime DueDate { get; set; }
        public BookFormat Format { get; set; }
        public BookStatus Status { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string RackPosition { get; set; }

        

    }
}
