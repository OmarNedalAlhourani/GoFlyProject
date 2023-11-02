using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GoFly.BL.Models.ViewModels;
using System.Data;

namespace GoFly.UI.Controllers
{
    [Authorize]

    public class AccountController : Controller
    {
        #region Confguration
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        #endregion

        #region Users
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.Mobile

                };

                var result = await _userManager.CreateAsync(user, model.Password!);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);

                }
                return View(model);
            }

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "HotTour", new {area="Admin"});

                }
                ModelState.AddModelError("", "Invaled username or password");


                return View(model);
            }


            return View(model);
        }


        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Role
        // [Authorize(Roles = "Adminstator")]
        public IActionResult RoleList()
        {

            return View(_roleManager.Roles);
        }
        [HttpGet]
        //  [Authorize(Roles = "Adminstator")]
        public IActionResult CreateRole()
        {


            return View();
        }
        [HttpPost]
        //   [Authorize(Roles = "Adminstator")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = model.RoleName
                };



                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {

                    return RedirectToAction("RoleList");
                }

                ModelState.AddModelError("", "not created");
                return View(model);
            };

            return View(model);
        }


        [HttpGet]
        //  [Authorize(Roles = "Adminstator")]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            EditRoleViewModel model = new EditRoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,

            };
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name!))
                {
                    model.Users.Add(user.Email!);
                }

            }
            return View(model);


        }

        [HttpPost]
        // [Authorize(Roles = "Adminstator")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId!);
                role.Name = model.RoleName;

                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(RoleList));

                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);


                }
                return View(model);
            }
            return View(model);
        }


        [HttpGet]
        //    [Authorize(Roles = "Adminstator")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = _roleManager.FindByIdAsync(id);

            return View(role);
        }

        [HttpPost]
        //   [Authorize(Roles = "Adminstator")]
        public async Task<IActionResult> DeleteRole(string Id, IdentityRole r)
        {

            if (Id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(Id);

            var res = await _roleManager.DeleteAsync(role!);

            if (res.Succeeded)
            {
                return RedirectToAction(nameof(RoleList));
            }
            return View(role);
        }


        [HttpGet]
        //   [Authorize(Roles = "Adminstator")]
        public async Task<IActionResult> UserRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(id);
            List<UserRoleViewModel> userRoleViewModel = new List<UserRoleViewModel>();

            foreach (var user in _userManager.Users)
            {
                UserRoleViewModel model = new UserRoleViewModel
                {
                    UserName = user.UserName,
                    UserId = user.Id


                };

                if (await _userManager.IsInRoleAsync(user, role.Name!))
                {

                    model.IsSelcted = true;
                }
                else
                {
                    model.IsSelcted = false;
                }

                userRoleViewModel.Add(model);

            }
            return View(userRoleViewModel);


        }

        [HttpPost]
        //   [Authorize(Roles = "Adminstator")]
        public async Task<IActionResult> UserRole(string id, List<UserRoleViewModel> models)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {

                return NotFound();
            }
            IdentityResult result = null;
            for (int i = 0; i < models.Count; i++)
            {

                var user = await _userManager.FindByIdAsync(models[i].UserId);

                if (models[i].IsSelcted && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!(models[i].IsSelcted) && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }


            }
            if (result.Succeeded)
            {
                return RedirectToAction("EditRole", new { id = id });

            }
            return View(models);

        }


        //  [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion

    }

}










