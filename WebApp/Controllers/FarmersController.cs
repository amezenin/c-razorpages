using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;
using Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class FarmersController : Controller
    {
        private readonly IAppBLL _bll;

        public FarmersController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: Farmers
        public async Task<IActionResult> Index()
        {
            
            /*var farmers = await _context.Farmers
                .Include(f => f.AppUser)
                .Where(p => p.AppUserId == User.GetUserId()).ToListAsync();*/
            
            var farmers = await _bll.Farmers.AllForUserAsync(User.GetUserId());
            
            return View(farmers);
        }

        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

           /* var farmer = await _context.Farmers
                .Include(f => f.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);*/
           
           var farmer = await _bll.Farmers.FindForUserAsync(id.Value, User.GetUserId());
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // GET: Farmers/Create
        public IActionResult Create()
        {
            //ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppUserId,Firstname,Lastname,Score,Id")] BLL.App.DTO.Farmer farmer)
        {
            farmer.AppUserId = User.GetUserId();
            if (ModelState.IsValid)
            {
                
                   /* _context.Add(farmer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));*/
                   _bll.Farmers.Add(farmer);
                   await _bll.SaveChangesAsync();
                   return RedirectToAction(nameof(Index));

                
                
            }
            //ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", farmer.AppUserId);
            return View(farmer);
        }

        // GET: Farmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var farmer = await _context.Farmers.FindAsync(id);
            var farmer = await _bll.Farmers.FindForUserAsync(id.Value, User.GetUserId());
            if (farmer == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", farmer.AppUserId);
            return View(farmer);
        }

        // POST: Farmers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BLL.App.DTO.Farmer farmer)
        {
            
            if (id != farmer.Id)
            {
                return NotFound();
            }
            
            // check for the ownership - is this Person record really belonging to logged in user.
            if (! await _bll.Farmers.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            //somebody can change all farms
            farmer.AppUserId = User.GetUserId();

           

            if (ModelState.IsValid)
            {
                _bll.Farmers.Update(farmer);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            //ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", farmer.AppUserId);
            return View(farmer);
        }

        // GET: Farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var farmer = await _context.Farmers
                .Include(f => f.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var farmer = await _bll.Farmers.FindForUserAsync(id.Value, User.GetUserId());
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var farmer = await _context.Farmers.FindAsync(id);
            _context.Farmers.Remove(farmer);
            await _context.SaveChangesAsync();*/
            
            // check for the ownership - is this Person record really belonging to logged in user.
            if (! await _bll.Farmers.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            _bll.Farmers.Remove(id);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
    }
}
