using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Arfitect.Training.PilotPeer.Models.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name="Rol ismi")]
        [Required(ErrorMessage = "Rol ismi gereklidir")]
        public string Name { get; set; }
        public string Id { get; set; }

    }
}
