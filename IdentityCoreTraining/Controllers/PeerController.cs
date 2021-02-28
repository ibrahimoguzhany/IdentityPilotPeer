using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityCoreTraining.Models.Context;
using IdentityCoreTraining.Models.Entities;
using IdentityCoreTraining.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IdentityCoreTraining.Controllers
{
    [Authorize(Roles = "Peer,Coordinator")]
    public class PeerController : BaseController
    {
        public PeerController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RequestContext context, RoleManager<AppRole> roleManager = null) : base(userManager, signInManager,context,roleManager)
        {
        }

        public IActionResult Index()
        {
            List<SupportRequest> requests = _context.SupportRequests.ToList();
            return View(requests);
        }

        public IActionResult RequestPage(SupportRequestViewModel supportRequestViewModel,string id)
        {
            supportRequestViewModel.Id = Guid.Parse(id);
            return View("RequestPage", supportRequestViewModel);
        }



    }
}
