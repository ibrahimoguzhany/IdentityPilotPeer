using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Artifect.PilotPeer.Models.Enums;

namespace Artifect.PilotPeer.Models.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanici ismi bos birakilamaz.")]
        [Display(Name = "Kullanici Adı")]
        public string UserName { get; set; }


        [Display(Name = "Telefon Numarasi")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email adresi gereklidir.")]
        [Display(Name = "Email Adresi")]
        [EmailAddress(ErrorMessage = "Email adresiniz dogru formatta degil")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Sifre Gereklidir")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Profil Resmi")]
        public string Picture { get; set; }

        [Display(Name = "Şehir")]
        public string City { get; set; }

        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }
    }
}
