using IdentityCoreTraining.Models.Entities;
using IdentityCoreTraining.Models.Enums;
using IdentityCoreTraining.Models.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IdentityCoreTraining.Controllers
{
   [Authorize]
    public class MemberController : BaseController
    {
        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) :base(userManager,signInManager,null)
        {
        }

        public IActionResult Index()
        {
            AppUser user = CurrentUser;
            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            return View(userViewModel);
        }

        
        public IActionResult EditUser()
        {
            AppUser user = CurrentUser;

            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));

            //ViewBag.Peer = new SelectList(_userManager.Users.Where(x=>x.UserRole == "Peer")));

            return View(userViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel userViewModel, IFormFile userPicture)
        {
            ModelState.Remove("Password");
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            if (ModelState.IsValid)
            {
                AppUser user = CurrentUser;

                if (userPicture != null && userPicture.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPictures", fileName);

                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        await userPicture.CopyToAsync(fs);

                        user.Picture = "/UserPictures/" + fileName;
                    }
                }

                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
                user.City = userViewModel.City;
                user.BirthDay = userViewModel.BirthDay;
                user.Gender = (int)userViewModel.Gender;

                IdentityResult result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(user,true);

                    ViewBag.success = "true";
                }
                else
                {
                   AddModelError(result);
                }
            }
            return View(userViewModel);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = CurrentUser;

                bool exist = _userManager.CheckPasswordAsync(user, changePasswordViewModel.OldPassword).Result;

                if (exist)
                {
                    IdentityResult result = _userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword,
                        changePasswordViewModel.NewPassword).Result;

                    if (result.Succeeded)
                    {
                        _userManager.UpdateSecurityStampAsync(user);
                        _signInManager.SignOutAsync();
                        _signInManager.PasswordSignInAsync(user,changePasswordViewModel.NewPassword,true,false);

                        ViewBag.success = "true";
                    }
                    else
                    {
                        AddModelError(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Eski sifreniz yanlis girildi");
                }
            }
            return View(changePasswordViewModel);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return Redirect("/Home/Login");

        }

        public IActionResult AccessDenied()
        {
            return View();
        }


    }

}
