using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace IdentityCoreTraining.Models.Entities
{

    public class AppUser : IdentityUser
    {

        public string? City { get; set; }
        public string? Picture { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? Gender { get; set; }
        public List<SupportRequest> SupportRequests { get; set; }


    }

   
}
