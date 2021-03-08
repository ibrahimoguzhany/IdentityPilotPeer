using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arfitect.Training.PilotPeer.Models.ViewModels
{
    public class PasswordResetViewModel
    {
        [Display(Name = "Email adresiniz")]
        [Required(ErrorMessage = "Email alani gereklidir.")]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Yeni Parolaniz")]
        [Required(ErrorMessage = "Parola gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Parolaniz en az 3 karakter olmalidir.")]
        public string NewPassword { get; set; }

        


    }
}
