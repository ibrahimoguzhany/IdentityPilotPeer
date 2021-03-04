using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artifect.PilotPeer.Models.Entities;
using Artifect.PilotPeer.Models.ViewModels;
using Artifect.PilotPeer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Mapster;
using Microsoft.AspNetCore.Authorization;

namespace Artifect.PilotPeer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {

        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : base(userManager, null, null,roleManager)
        {
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel roleViewModel)
        {
            AppRole role = new AppRole();
            role.Name = roleViewModel.Name;

            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            else
            {
                AddModelError(result);
            }


            return View(roleViewModel);
        }


        public IActionResult RoleList()
        {
            return View(_roleManager.Roles.ToList());
        }


        public IActionResult UserList()
        {
            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> DeleteRole(string Id)
        {
            AppRole role = await _roleManager.FindByIdAsync(Id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

            }

            return RedirectToAction("RoleList");
        }

        public IActionResult UpdateRole(string id)
        {
            AppRole role = _roleManager.FindByIdAsync(id).Result;

            if (role != null)
            {
                return View(role.Adapt<RoleViewModel>());
            }

            return RedirectToAction("RoleList");
        }

        [HttpPost]
        public IActionResult UpdateRole(RoleViewModel roleViewModel)
        {
            AppRole role = _roleManager.FindByIdAsync(roleViewModel.Id).Result;

            if (role != null)
            {
                role.Name = roleViewModel.Name;
                IdentityResult result = _roleManager.UpdateAsync(role).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    AddModelError(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "Güncelleme işlemi başarısız oldu.");
            }
            return View(roleViewModel);
        }

        public IActionResult AssignRole(string id)
        {
            TempData["userId"] = id;
            AppUser user = _userManager.FindByIdAsync(id).Result;

            ViewBag.userName = user.UserName;

            IQueryable<AppRole> roles = _roleManager.Roles;

            List<string> userRoles = _userManager.GetRolesAsync(user).Result as List<string>;

            List<AssignRoleViewModel> assignRoleViewModel = new List<AssignRoleViewModel>();

            foreach (var role in roles)
            {
                AssignRoleViewModel ravm = new AssignRoleViewModel();
                ravm.RoleId = role.Id;
                ravm.RoleName = role.Name;
                if (userRoles.Contains(role.Name))
                    ravm.Exist = true;
                else
                    ravm.Exist = false;

                assignRoleViewModel.Add(ravm);
            }

            return View(assignRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleViewModel> assignRoleViewModels)
        {
            AppUser user = _userManager.FindByIdAsync(TempData["userId"].ToString()).Result;

            foreach (var item in assignRoleViewModels)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("UserList");
        }


    }


}
