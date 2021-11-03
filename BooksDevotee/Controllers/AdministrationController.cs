using BooksDevotee.Models;
using BooksDevotee.ViewModels.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDevotee.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            ListRolesViewModel viewModel = new ListRolesViewModel();
            viewModel.Roles = roleManager.Roles.ToList();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            IdentityRole role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Nie odnaleziono roli o id = {roleId}";
                return View("NotFound");
            }

            EditUsersInRoleViewModel model = new EditUsersInRoleViewModel();
            model.RoleId = roleId;
            model.UsersInRole = new List<UserRoleViewModel>();

            foreach (ApplicationUser user in userManager.Users.ToList())
            {
                UserRoleViewModel userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.UsersInRole.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(EditUsersInRoleViewModel model, string roleId)
        {
            IdentityRole role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.UsersInRole.Count; i++)
            {
                ApplicationUser user = await userManager.FindByIdAsync(model.UsersInRole[i].UserId);

                if (model.UsersInRole[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model.UsersInRole[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    await userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }

            return RedirectToAction("ListRoles");
        }
    }
}
