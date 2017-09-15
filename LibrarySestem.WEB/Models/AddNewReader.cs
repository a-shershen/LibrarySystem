using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySestem.WEB.Models
{
    public class AddNewReader
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}