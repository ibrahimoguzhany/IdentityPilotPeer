using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using IdentityCoreTraining.Models.Enums;

namespace IdentityCoreTraining.Models.Entities
{
    public class SupportRequest
    {
        public SupportRequest()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PeerNote { get; set; }
        public HowSoonWantsToBeContacted HowSoonWantsToBeContacted { get; set; }
        public LanguagePreferency LanguagePreferency { get; set; }
        public BaseInformation BaseInformation { get; set; }

        public DataStatus Status { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
