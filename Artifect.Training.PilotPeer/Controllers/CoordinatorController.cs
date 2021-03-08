using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Arfitect.Training.PilotPeer.Models.Context;
using Arfitect.Training.PilotPeer.Models.Entities;
using Arfitect.Training.PilotPeer.Models.Enums;
using Arfitect.Training.PilotPeer.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Arfitect.Training.PilotPeer.Controllers
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
            SupportRequest request = _context.SupportRequests.Where(x => x.Id.ToString() == id).FirstOrDefault();

            supportRequestViewModel.Email = request.Email;
            supportRequestViewModel.PhoneNumber = request.PhoneNumber;
            supportRequestViewModel.UserId = request.UserId;

            supportRequestViewModel.Id = Guid.Parse(id);

            supportRequestViewModel.PeerNote =
                _context.SupportRequests.Select(x => x.PeerNote).FirstOrDefault();

            var users = _userManager.Users.ToList();
            var peerUsers = new List<AppUser>();
            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Peer"))
                {
                    peerUsers.Add(user);
                }
            }

            var peerList = peerUsers.Select(c => new SelectListItem
            {
                Value = c.Id,
                Text = c.UserName
            });

            ViewBag.peerList = peerList;


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
            request.Email = supportRequestViewModel.Email;
            request.PhoneNumber = supportRequestViewModel.PhoneNumber;
            request.PeerName = supportRequestViewModel.PeerName;


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
