using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerValidation.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Age { get; set; }
        public string Address { get; set; }
        public long Contact { get; set; }

    }
}