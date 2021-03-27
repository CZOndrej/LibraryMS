using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS.Models
{
    public class CreateBook
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int NumberOfPages { get; set; }
    }
}
