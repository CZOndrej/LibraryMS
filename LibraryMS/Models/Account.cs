using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LibraryMS.Models
{
    public class Account: IdentityUser
    {
        public AccountStatus Status { get; set; }
        public Person Person { get; set; }
        public virtual ICollection<BookItem> Borrows { get; set; }
        public virtual ICollection<BookReservation> Reservations { get; set; }
        public DateTime DateOfMembership { get; set; }
        public int TotalBooksCheckedout { get; set; }
        public LibraryCard LibraryCard { get; set; }

    }
}
