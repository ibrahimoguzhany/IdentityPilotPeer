using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCoreTraining.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name="Email adresiniz")]
        [Required(ErrorMessage = "Email alani gereklidir.")]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Parolaniz")]
        [Required(ErrorMessage = "Parola gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage = "Parolaniz en az 3 karakter olmalidir.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }


    }
}
