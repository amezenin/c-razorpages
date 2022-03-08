using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class FishTypesController : Controller
    {
        private readonly IAppBLL _bll;

        public FishTypesController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: FishTypes
        public async Task<IActionResult> Index()
        {
            return View(await _bll.FishTypes.GetAllWithFishTypeCountAsync());
        }

        // GET: FishTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var fishType = await _context.FishTypes
                .FirstOrDefaultAsync(m => m.Id == id);*/
            
            var fishType = await _bll.FishTypes.FindAsync(id);
            if (fishType == null)
            {
                return NotFound();
            }

            return View(fishType);
        }

        // GET: FishTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FishTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Species,MinTemp,MaxTemp,MaxNo,MaxNh,MaxDensity,Id")] BLL.App.DTO.FishType fishType)
        {
            if (ModelState.IsValid)
           {
                /*_context.Add(fishType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));*/
                _bll.FishTypes.Add(fishType);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(fishType);
        }

        // GET: FishTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var fishType = await _context.FishTypes.FindAsync(id);
            
            var fishType = await _bll.FishTypes.FindAsync(id);
            if (fishType == null)
            {
                return NotFound();
            }
            return View(fishType);
        }

        // POST: FishTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BLL.App.DTO.FishType fishType)
        {
            if (id != fishType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.FishTypes.Update(fishType);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(fishType);
        }

        // GET: FishTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishType = await _bll.FishTypes.FindAsync(id);
            if (fishType == null)
            {
                return NotFound();
            }

            return View(fishType);
        }

        // POST: FishTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var fishType = await _context.FishTypes.FindAsync(id);
            _context.FishTypes.Remove(fishType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));*/
            
            _bll.FishTypes.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

       
    }
}
