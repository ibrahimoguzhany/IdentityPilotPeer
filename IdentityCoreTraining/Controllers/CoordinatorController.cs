using IdentityCoreTraining.Models.Context;
using IdentityCoreTraining.Models.Entities;
using IdentityCoreTraining.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityCoreTraining.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
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

        public IActionResult EditRequest(SupportRequestViewModel supportRequestViewModel, string id)
        {
            //ViewBag.peers =  _userManager.GetUsersInRoleAsync("Peer") ;
            supportRequestViewModel.Id = Guid.Parse(id);

            
            var peerList = _userManager.Users.Select(c => new SelectListItem
            {
                Value = c.Id,
                Text = c.UserName
            });
            ViewBag.peerList = peerList;

            supportRequestViewModel.PeerNote =
                _context.SupportRequests.Where(x => x.UserId == id).Select(x => x.PeerNote).FirstOrDefault();

            var status = (from DataStatus s in Enum.GetValues(typeof(DataStatus))
                select new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                });
            
            ViewBag.status = status;


            return View("EditRequest", supportRequestViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRequest(SupportRequestViewModel supportRequestViewModel)
        {
            AppUser user = await _userManager.FindByIdAsync(supportRequestViewModel.UserId);
            SupportRequest request = await _context.SupportRequests.FindAsync(supportRequestViewModel.Id);

            request.PeerNote = supportRequestViewModel.PeerNote;
            request.UserId = supportRequestViewModel.UserId;
            request.Status = supportRequestViewModel.Status;


            _context.SupportRequests.Attach(request);
            _context.SupportRequests.Update(request);
            _context.Entry(request).State = request.UserId == "0" ? EntityState.Added : EntityState.Modified;


            int result = await _context.SaveChangesAsync();
            

            if (result > 0)
            {
                return RedirectToAction("Index", "Coordinator");
            }

            return View(supportRequestViewModel);
        }

    }
}
