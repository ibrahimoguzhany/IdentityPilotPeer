using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Arfitect.Training.PilotPeer.Models.Entities;
using Arfitect.Training.PilotPeer.Models.Enums;

namespace Arfitect.Training.PilotPeer.Models.ViewModels
{
    public class SupportRequestViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "İsim alanı gereklidir")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email adresi gereklidir")]
        [Display(Name = "Email Adresi")]
        [EmailAddress(ErrorMessage = "Email adresiniz dogru formatta degil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon Numarasi")]
        [Display(Name = "Telefon Numarasi")]
        public string PhoneNumber { get; set; }
        public string PeerNote { get; set; }
        public string? PeerName { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public DataStatus Status { get; set; }
        public BaseInformation BaseInformation { get; set; }
        public LanguagePreferency LanguagePreferency { get; set; }
        public HowSoonWantsToBeContacted HowSoonWantsToBeContacted { get; set; }
    }
}
