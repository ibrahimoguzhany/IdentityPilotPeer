using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artifect.PilotPeer.Models.Context;
using Artifect.PilotPeer.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Artifect.PilotPeer.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<AppUser> _userManager { get; }
        protected SignInManager<AppUser> _signInManager { get; }
        protected RoleManager<AppRole> _roleManager { get; }
        protected AppUser CurrentUser => _userManager.FindByNameAsync(User.Identity.Name).Result;
        protected RequestContext _context { get; }


        public BaseController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RequestContext context, RoleManager<AppRole> roleManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void AddModelError(IdentityResult result)
        {
            foreach (var res in result.Errors)
            {
                ModelState.AddModelError("", res.Description);
            }
        }













    }
}
