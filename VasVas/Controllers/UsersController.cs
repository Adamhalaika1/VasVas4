using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VasVas.Models;


namespace VasVas.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(UserManager<ApplicationUser> UserManager)
        {
            _userManager = UserManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                CompanyName = user.CompanyName,
                SmsIdName = user.SmsIdName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
            }
            ).ToListAsync();

            return View(users);
        }
        //Get
        public async Task<IActionResult> Add()
        {
            var viewmodel = new AddUserViewModel
            {

            };
            return View(viewmodel);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model, [FromServices] UserManager<ApplicationUser> userManager)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingEmailUser = await userManager.FindByEmailAsync(model.Email);
            if (existingEmailUser != null)
            {
                ModelState.AddModelError("Email", "الأيميل موجود بالفعل");
                return View(model);
            }

            var existingCompanyUser = await userManager.FindByNameAsync(model.CompanyName);
            if (existingCompanyUser != null)
            {
                ModelState.AddModelError("CompanyName", "الشركة موجودة بالفعل");
                return View(model);
            }

            var user = new ApplicationUser
            {

                CompanyName = model.CompanyName,
                PhoneNumber = model.PhoneNumber,
                SmsIdName = model.SmsIdName,
                ConnectionPointName = model.ConnectionPointName,
                Email = model.Email,
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // User creation successful, you can redirect to the desired page.
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Handle user creation errors.
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            }

        //Get
        public async Task<IActionResult> Edit(string userId)
        {
            var users = await _userManager.FindByIdAsync(userId);
            var viewmodel = new ProfileFormViewModel
            {
                Id = users.Id,
                CompanyName = users.CompanyName,
                SmsIdName = users.SmsIdName,
                PhoneNumber = users.PhoneNumber,
                Email = users.Email
            };
            return View(viewmodel);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }
            var userwithsameEmail = await _userManager.FindByEmailAsync(model.Email);

            if (userwithsameEmail != null && userwithsameEmail.Id !=model.Id) 
            {
                ModelState.AddModelError("Email", "الأيميل موجود بالفعل ");
                return View(model);
            }
            user.CompanyName = model.CompanyName;
            user.SmsIdName = model.SmsIdName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }


    }

}


