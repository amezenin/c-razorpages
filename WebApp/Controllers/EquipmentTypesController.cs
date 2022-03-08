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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class EquipmentTypesController : Controller
    {
        private readonly IAppBLL _bll;

        public EquipmentTypesController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: EquipmentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _bll.EquipmentTypes.GetAllWithEquipmentTypeCountAsync());
        }

        // GET: EquipmentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentType = await _bll.EquipmentTypes.FindAsync(id.Value);
            if (equipmentType == null)
            {
                return NotFound();
            }

            return View(equipmentType);
        }

        // GET: EquipmentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] BLL.App.DTO.EquipmentType equipmentType)
        {
            if (ModelState.IsValid)
            {
                _bll.EquipmentTypes.Add(equipmentType);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(equipmentType);
        }

        // GET: EquipmentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentType = await _bll.EquipmentTypes.FindAsync(id.Value);
            if (equipmentType == null)
            {
                return NotFound();
            }
            return View(equipmentType);
        }

        // POST: EquipmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] BLL.App.DTO.EquipmentType equipmentType)
        {
            if (id != equipmentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.EquipmentTypes.Update(equipmentType);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
                
            }
            return View(equipmentType);
        }

        // GET: EquipmentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipmentType = await _bll.EquipmentTypes.FindAsync(id.Value);
            if (equipmentType == null)
            {
                return NotFound();
            }

            return View(equipmentType);
        }

        // POST: EquipmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.EquipmentTypes.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            
        }

        
    }
}
