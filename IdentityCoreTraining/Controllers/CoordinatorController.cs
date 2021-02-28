using IdentityCoreTraining.Models.Context;
using IdentityCoreTraining.Models.Entities;
using IdentityCoreTraining.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IdentityCoreTraining.Controllers
{
    [Authorize(Roles = "Coordinator")]
    public class CoordinatorController : BaseController
    {
        public CoordinatorController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RequestContext context, RoleManager<AppRole> roleManager = null) : base(userManager, signInManager, context, roleManager)
        {
        }
        public IActionResult Index()
        {
            List<SupportRequest> requestList = _context.SupportRequests.ToList();

            return View(requestList);
        }

        public async Task<IActionResult> EditRequest(SupportRequestViewModel supportRequestViewModel, string id)
        {
            ViewBag.peers = await _userManager.GetUsersInRoleAsync("Peer") as List<AppUser>;
            supportRequestViewModel.Id = Guid.Parse(id);
            return View("EditRequest", supportRequestViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRequest(SupportRequestViewModel supportRequestViewModel)
        {
            AppUser user = await _userManager.FindByIdAsync(supportRequestViewModel.UserId);
            SupportRequest request = await _context.SupportRequests.FindAsync(supportRequestViewModel.Id);

            request.PeerNote = supportRequestViewModel.PeerNote;
            request.User.Id = supportRequestViewModel.UserId;
            request.Status = supportRequestViewModel.Status;


             _context.SupportRequests.Update(request);
             _context.SupportRequests.Attach(request);

            _context.Entry(request).State = EntityState.Modified;

            int result =await _context.SaveChangesAsync();

            if (result > 0)
            {
                return RedirectToAction("Index", "Coordinator");
            }

            return View(supportRequestViewModel);
        }

    }
}
