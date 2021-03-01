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
using Microsoft.EntityFrameworkCore;

namespace IdentityCoreTraining.Controllers
{
    [Authorize(Roles = "Peer")]
    public class PeerController : BaseController
    {
        public PeerController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RequestContext context, RoleManager<AppRole> roleManager = null) : base(userManager, signInManager, context, roleManager)
        {
        }

        public IActionResult Index()
        {
            List<SupportRequest> requests = _context.SupportRequests.ToList();
            
            return View(requests);
        }

        public IActionResult RequestPage(SupportRequestViewModel supportRequestViewModel, string id)
        {
            SupportRequest request = _context.SupportRequests.Find(Guid.Parse(id));

            supportRequestViewModel.Id = Guid.Parse(id);
            supportRequestViewModel.Name = request.Name;
            supportRequestViewModel.Email = request.Email;
            supportRequestViewModel.PhoneNumber = request.PhoneNumber;
            supportRequestViewModel.PeerNote = request.PeerNote;
            supportRequestViewModel.UserId = request.UserId;
            return View("RequestPage", supportRequestViewModel);
        }

        public async Task<IActionResult> EditRequest(string id)
        {
            SupportRequest request = await _context.SupportRequests.Where(x=>x.Id == Guid.Parse(id)).FirstOrDefaultAsync();

            SupportRequestViewModel supportRequestViewModel = new SupportRequestViewModel();
            supportRequestViewModel.PeerNote = request.PeerNote;
            supportRequestViewModel.Id = Guid.Parse(id);

            return View(supportRequestViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRequest(SupportRequestViewModel supportRequestViewModel, string id)
        {
            SupportRequest request = await _context.SupportRequests.Where(x=>x.Id == Guid.Parse(id)).FirstOrDefaultAsync();
            request.PeerNote = supportRequestViewModel.PeerNote;


            _context.SupportRequests.Attach(request);
            _context.SupportRequests.Update(request);
            _context.Entry(request).State = EntityState.Modified;

            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return RedirectToAction("Index", "Peer");
            }

            return View(supportRequestViewModel);
        }



    }
}
