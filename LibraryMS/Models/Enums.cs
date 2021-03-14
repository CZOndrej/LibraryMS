using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Models
{
    public enum BookFormat
    {
        Hardcover,
        Paperback,
        Audiobook,
        Ebook,
        Newspaper,
        Magazine,
        Journal
    }

    public enum BookStatus
    {
        Available,
        Reserved,
        Loaned,
        Lost
    }

    public enum ReservationStatus
    {
        Waiting,
        Pending,
        Completed,
        Canceled,
        None
    }

    public enum AccountStatus
    {
        Active,
        Closed,
        Canceled,
        Blacklisted,
        None
    }
}
