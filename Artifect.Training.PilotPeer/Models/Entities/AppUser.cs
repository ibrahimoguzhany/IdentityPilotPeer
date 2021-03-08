using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


namespace Arfitect.Training.PilotPeer.Models.Entities
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
