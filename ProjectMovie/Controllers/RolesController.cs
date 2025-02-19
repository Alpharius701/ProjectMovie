using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectMovie.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectMovie.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    public class RolesController(
        RoleManager<IdentityRole> roleManager,
        UserManager<IdentityUser> userManager) : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        [HttpGet]
        public ViewResult Index() => View(_roleManager.Roles);

        [HttpGet]
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }

            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole? role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
            {
                ModelState.AddModelError("", "No role found");
            }

            return View("Index", _roleManager.Roles);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole? role = await _roleManager.FindByIdAsync(id);

            List<IdentityUser> members = [];
            List<IdentityUser> nonMembers = [];

            foreach (IdentityUser user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role!.Name!) ? members : nonMembers;
                list.Add(user);
            }

            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? [])
                {
                    IdentityUser? user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName!);

                        if (!result.Succeeded)
                            Errors(result);
                    }
                }

                foreach (string userId in model.DeleteIds ?? [])
                {
                    IdentityUser? user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName!);

                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId!);
        }
    }
}
