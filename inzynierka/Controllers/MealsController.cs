using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using inzynierka.Data;
using inzynierka.Models;
using inzynierka.Models.MealViewModels;

namespace inzynierka.Controllers
{
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> HowManyTimeoccursInDiet(Guid id)
        {
            return await _context.MealDietLists.Where(x => x.MealId == id).CountAsync();
        }

        public async Task<List<IndexViewModel>> GetDietList()
        {
            var dataList = await _context.Meals.ToListAsync();
            var mealList = new List<IndexViewModel>();
            foreach (var item in dataList)
            {
                var temp = new IndexViewModel
                {
                    HowManyTimeoccursInDiet = await HowManyTimeoccursInDiet(item.MealId),
                    MealId = item.MealId,
                    MealName = item.MealName,
                    MealType = item.MealType,
                    Components = item.Components
                };
                mealList.Add(temp);
            }

            return mealList;
        }

        // GET: Meals
        public async Task<IActionResult> Index()
        {
            return View(await GetDietList());
        }

        // GET: Meals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .SingleOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // GET: Meals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel meal)
        {
            if (ModelState.IsValid)
            {
                meal.MealId = Guid.NewGuid();
                var data = new Meal()
                {
                    Components = meal.Components,
                    MealId = meal.MealId,
                    MealName = meal.MealName,
                    MealType = meal.MealType
                };
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meal);
        }

        // GET: Meals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.SingleOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return NotFound();
            }
            var model = new EditViewModel()
            {
                Components = meal.Components,
                MealId = meal.MealId,
                MealName = meal.MealName,
                MealType = meal.MealType
            };
            return View(model);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditViewModel meal)
        {
            
            if (id != meal.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var model = new Meal
                    {
                        Components = meal.Components,
                        MealId = meal.MealId,
                        MealName = meal.MealName,
                        MealType = meal.MealType
                    };
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(meal.MealId))
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
            return View(meal);
        }

        // GET: Meals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals
                .SingleOrDefaultAsync(m => m.MealId == id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var meal = await _context.Meals.SingleOrDefaultAsync(m => m.MealId == id);
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(Guid id)
        {
            return _context.Meals.Any(e => e.MealId == id);
        }
    }
}
