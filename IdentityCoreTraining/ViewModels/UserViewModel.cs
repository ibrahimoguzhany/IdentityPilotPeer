using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCoreTraining.ViewModels
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
        [Display(Name = "Sifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }






    }
}
