using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arfitect.Training.PilotPeer.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Yeni Parolaniz")]
        [Required(ErrorMessage = "Parola gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Parolaniz en az 3 karakter olmalidir.")]
        public string NewPassword { get; set; }

        [Display(Name = "Parola onay")]
        [Required(ErrorMessage = "Parola gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Parolaniz en az 3 karakter olmalidir.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Eski Parolaniz")]
        [Required(ErrorMessage = "Parola gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Parolaniz en az 3 karakter olmalidir.")]
        public string OldPassword { get; set; }

    }
}
