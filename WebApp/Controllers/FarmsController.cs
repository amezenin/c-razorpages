using System;
using System.Collections.Generic;
using System.Linq;
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
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class FarmsController : Controller
    {
        private readonly IAppBLL _bll;

        public FarmsController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: Farms
        public async Task<IActionResult> Index()
        {
            
            /*var appDbContext = _context.Farms
                .Include(f => f.Farmer)
                .Where(p => p.Farmer.AppUserId == User.GetUserId());*/
            
            var farms = await _bll.Farms.AllForUserAsync(User.GetUserId());
            return View(farms);
        }

        // GET: Farms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           /* var farm = await _context.Farms
                .Include(f => f.Farmer)
                .FirstOrDefaultAsync(m => m.Id == id);*/
           var farm = await _bll.Farms.FindForUserAsync(id.Value, User.GetUserId());
            if (farm == null)
            {
                return NotFound();
            }

            return View(farm);
        }

        // GET: Farms/Create
        public async Task<IActionResult> Create()
        {
            var vm = new FarmCreateEditViewModel()
            {
                FarmerSelectList = new SelectList(
                    
                    await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                    nameof(BLL.App.DTO.Farmer.Id), 
                    nameof(BLL.App.DTO.Farmer.Lastname))
                
            };
            return View(vm);

        }

        // POST: Farms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(FarmCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                
                _bll.Farms.Add(vm.Farm);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.FarmerSelectList = new SelectList(
                await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farmer.Id),
                nameof(BLL.App.DTO.Farmer.Lastname),
                vm.Farm.FarmerId);
            
            return View(vm);

        }

        // GET: Farms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            //maybe that
            //var farm = await _bll.Farms.FindForUserAsync(id.Value, User.GetUserId());
            var farm = await _bll.Farms.FindForUserAsync(id.Value, User.GetUserId());
            if (farm == null)
            {
                return NotFound();
            }
            
            var vm = new FarmCreateEditViewModel();
            vm.Farm = farm;
            vm.FarmerSelectList = new SelectList(
                await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farmer.Id),
                nameof(BLL.App.DTO.Farmer.Lastname),
                vm.Farm.FarmerId);

            //ViewData["FarmerId"] = new SelectList(_context.Farmers, "Id", "Firstname", farm.FarmerId);
            return View(vm);
        }
        
        

        // POST: Farms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FarmCreateEditViewModel vm)
        {
            if (id != vm.Farm.Id)
            {
                return NotFound();
            }

            
            // check for the ownership - is this Person record really belonging to logged in user.
            if (! await _bll.Farms.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }


           
            if (ModelState.IsValid)
            {
                _bll.Farms.Update(vm.Farm);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            //ViewData["FarmerId"] = new SelectList(_context.Farmers, "Id", "Firstname", farm.FarmerId);
            
            vm.FarmerSelectList = new SelectList(
                await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farmer.Id),
                nameof(BLL.App.DTO.Farmer.Lastname),
                vm.Farm.FarmerId);

            return View(vm);
        }

        // GET: Farms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var farm = await _context.Farms
                .Include(f => f.Farmer)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var farm = await _bll.Farms.FindForUserAsync(id.Value, User.GetUserId());
            if (farm == null)
            {
                return NotFound();
            }

            return View(farm);
        }

        // POST: Farms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var farm = await _bll.Farms.FindForUserAsync(id, User.GetUserId());
            
            if (!await _bll.Farms.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Farms.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        
    }
}
