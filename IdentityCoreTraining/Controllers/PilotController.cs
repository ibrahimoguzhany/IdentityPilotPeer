using System.Threading.Tasks;
using IdentityCoreTraining.Models;
using IdentityCoreTraining.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Mapster;

namespace IdentityCoreTraining.Controllers
{
    [Authorize]
    public class PilotController : Controller
    {

        public UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public PilotController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            AppUser user = _userManager.FindByNameAsync("oguzhany").Result; // TODO: FindByNameAsync düzgün çalışmıyor. 'oguzhan' vermek yerine User.Identity.Name ile kullanıcıyı buldurtmanın bir yolunu bul.
            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            return View(userViewModel);
        }

        public IActionResult EditUser()
        {
            AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            UserViewModel userViewModel = user.Adapt<UserViewModel>();

            return View(userViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel userViewModel)
        {
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;

                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;


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
                    foreach (var res in result.Errors)
                    {
                        ModelState.AddModelError("",res.Description);
                    }
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
                AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;

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
                        foreach (var res in result.Errors)
                        {
                            ModelState.AddModelError("",res.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Eski sifreniz yanlis girildi");
                }
            }
            return View(changePasswordViewModel);
        }

        public void Logout()
        {
            _signInManager.SignOutAsync();

        }
    }
}
