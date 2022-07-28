using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyRegistration.Models
{
    public class ClS
    {
        public int RegisterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<ClS>lstcls { get; set; }

    }
}