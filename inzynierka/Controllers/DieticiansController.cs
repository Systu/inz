using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using inzynierka.Data;
using inzynierka.Models;
using inzynierka.Models.DieticiansViewModels;
using inzynierka.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace inzynierka.Controllers
{
    public class DieticiansController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public DieticiansController( ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                                    IEmailSender emailSender,
                                    ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<IndexViewModel>> GetDieticianListAsync()
        {
            var user = await _userManager.GetUsersInRoleAsync("Dietician");

            return user.Select(item => new IndexViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Surname = item.Surname,
                Email = item.Email,
                Age = item.Age,
                AddeDateTime = item.AddeDateTime,
                PhoneNumber = item.PhoneNumber
            }).ToList();
        }
        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            
            return View(await GetDieticianListAsync());
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model,string returnUrl= null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    Age = model.Age,
                    Surname = model.Surname,
                    PhoneNumber = model.PhoneNumber,
                    AddeDateTime = DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, "Zaq!2wsx");
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    await _userManager.AddToRoleAsync(user, "Dietician");
                    _logger.LogInformation("Role added to User");
                    return View("Index", await GetDieticianListAsync());
                }
                AddErrors(result);
            }
            return View(model);
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            var model = new EditViewModel
            {
                Id = applicationUser.Id,
                Name = applicationUser.Name,
                Surname = applicationUser.Surname,
                Email = applicationUser.Email,
                Age = applicationUser.Age,
                PhoneNumber = applicationUser.PhoneNumber
            };
            
            return View(model);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user =await _userManager.FindByIdAsync(model.Id);
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Age = model.Age;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    await _userManager.UpdateAsync(user);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await ApplicationUserExists(model.Id))
                    {
                        throw;
                    }

                    return NotFound();
                }
                return View("Index", await GetDieticianListAsync());
            }
            return View(model);
        }

        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _userManager.FindByIdAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            var model = new DeleteViewModel
            {
                Age = applicationUser.Age,
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                Name = applicationUser.Name,
                PhoneNumber = applicationUser.PhoneNumber,
                Surname = applicationUser.Surname
            };
            return View(model);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ApplicationUserExists(string id)
        {
            return await _userManager.FindByIdAsync(id) != null;
        }
        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Index");
            }
        }

        #endregion
    }
}
