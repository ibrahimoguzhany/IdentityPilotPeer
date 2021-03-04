using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Arfitect.Training.PilotPeer.Models.Context;
using Arfitect.Training.PilotPeer.Models.Entities;
using Arfitect.Training.PilotPeer.Models.ViewModels;
using Arfitect.Training.PilotPeer.Models.Enums;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Arfitect.Training.PilotPeer.Controllers
{

    public class HomeController : BaseController
    {
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RequestContext context) : base(
            userManager, signInManager, context, null)
        { 
        }

        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    SignInResult result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, loginViewModel.RememberMe, false);

                    if (result.Succeeded)
                    {
                        if (TempData["ReturnUrl"] != null)
                            return Redirect(TempData["ReturnUrl"].ToString());
                        
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                            return RedirectToAction("Index", "Admin");

                        else if (await _userManager.IsInRoleAsync(user, "Peer"))
                            return RedirectToAction("Index" ,"Peer");
                        
                        else if (await _userManager.IsInRoleAsync(user, "Coordinator"))
                            return RedirectToAction("Index", "Coordinator");
                        
                        else if (await _userManager.IsInRoleAsync(user, "Member"))
                            return RedirectToAction("Index", "Member");
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Gecersiz email veya sifresi");
                }
            }
            return View(loginViewModel);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;

                IdentityResult result = await _userManager.CreateAsync(user, userViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    AddModelError(result);
                }
            }

            return View(userViewModel);
        }
        public IActionResult CreateRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRequest(SupportRequestViewModel supportRequestViewModel)
        {

            SupportRequest request = new SupportRequest();

            request.BaseInformation = supportRequestViewModel.BaseInformation;
            request.Email = supportRequestViewModel.Email;
            request.HowSoonWantsToBeContacted = supportRequestViewModel.HowSoonWantsToBeContacted;
            request.LanguagePreferency = supportRequestViewModel.LanguagePreferency;
            request.Name = supportRequestViewModel.Name;
            request.PhoneNumber = supportRequestViewModel.PhoneNumber;
            request.Status = supportRequestViewModel.Status;
            request.PeerNote = supportRequestViewModel.PeerNote;

            _context.SupportRequests.Add(request);
            _context.SupportRequests.Attach(request);
            _context.Entry(request).State = EntityState.Added;
            int result = _context.SaveChanges();

            if (result > 0)
            {
                ViewBag.success = "Form Gonderildi";
                return RedirectToAction("Index", "Home");
            }
            return View(supportRequestViewModel);

        }
    }
}
