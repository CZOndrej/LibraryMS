using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Models
{
    public class BookReservation
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public ReservationStatus Status { get; set; }
        public BookItem BookItem { get; set; }
    }
}
