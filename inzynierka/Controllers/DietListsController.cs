using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using inzynierka.Data;
using inzynierka.Models;
using inzynierka.Models.DietListViewModels;
using inzynierka.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.Extensions.Logging;

namespace inzynierka.Controllers
{
    public class DietListsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public DietListsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _contextAccessor = contextAccessor;
        }
        public async Task<int> GetCustomersCountPerDietAsync(Guid id)
        {
            var user = await _userManager.GetUsersInRoleAsync("Customers");
            var currentlyLogInUser = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).Result;

            return user.Where(item => item.DieticianId == currentlyLogInUser.Id).Count(item => item.DietId == id);
        }

        public async Task<int> GetMealCountPerDietAsync(Guid id)
        {

            return await _context.MealDietLists.Where(s => s.DietListId == id).CountAsync();

        }

        public async Task<List<IndexViewModel>> GetDietListToIndex()
        {
            
            var indexData = await _context.DietLists.ToListAsync();
            var model = new List<IndexViewModel>();
            foreach (var item in indexData)
            {
                var temp = new IndexViewModel
                {
                    AddedTime = item.AddedDataTime,
                    CustomerCount = await GetCustomersCountPerDietAsync(item.DietListId),
                    Id = item.DietListId,
                    DietName = item.DietName,
                    MealCount = await GetMealCountPerDietAsync(item.DietListId)
                };
                model.Add(temp);
            }
            return model;
        }
        // GET: DietLists
        public async Task<IActionResult> Index()
        {
            return View(await GetDietListToIndex());
        }

        // GET: DietLists/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietList = await _context.DietLists
                .SingleOrDefaultAsync(m => m.DietListId == id);
            if (dietList == null)
            {
                return NotFound();
            }

            return View(dietList);
        }

        // GET: DietLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DietLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel dietList)
        {
            dietList.AddeDateTime = DateTime.Now;
            if (ModelState != null && ModelState.IsValid)
            {
                dietList.DietListId = Guid.NewGuid();
                var saveItem = new DietList
                {
                    AddedDataTime = dietList.AddeDateTime,
                    Describe = dietList.Describe,
                    DietListId = dietList.DietListId,
                    DietName = dietList.DietName
                };
                _context.Add(saveItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dietList);
        }

        // GET: DietLists/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var dietList = await _context.DietLists.SingleOrDefaultAsync(m => m.DietListId == id);
            if (dietList == null)
            {
                return NotFound();
            }

            var model = new EditViewModel()
            {
                DietListId = dietList.DietListId,
                Describe = dietList.Describe,
                DietName = dietList.DietName
            };
            return View(model);
        }

        // POST: DietLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditViewModel dietList)
        {
            if (id != dietList.DietListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dietList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietListExists(dietList.DietListId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dietList);
        }

        // GET: DietLists/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietList = await _context.DietLists
                .SingleOrDefaultAsync(m => m.DietListId == id);
            if (dietList == null)
            {
                return NotFound();
            }

            var model = new DeleteViewModel
            {
                DietListId = dietList.DietListId,
                Describe = dietList.Describe,
                DietName = dietList.DietName,
                AddedTime = dietList.AddedDataTime
            };
            return View(model);
        }

        // POST: DietLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dietList = await _context.DietLists.SingleOrDefaultAsync(m => m.DietListId == id);
            _context.DietLists.Remove(dietList);
            var mealWhereDeletedDiet = await _context.MealDietLists.Where(s => s.DietListId == id).ToListAsync();
            foreach (var item in mealWhereDeletedDiet)
            {
                 _context.MealDietLists.Remove(item);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietListExists(Guid id)
        {
            return _context.DietLists.Any(e => e.DietListId == id);
        }
    }
}
