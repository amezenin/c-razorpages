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
    public class EquipmentsController : Controller
    {
        private readonly IAppBLL _bll;

        public EquipmentsController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var equipment = await _bll.Equipments.AllForUserAsync(User.GetUserId());
            return View(equipment);
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _bll.Equipments.FindForUserAsync(id.Value, User.GetUserId());
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipments/Create
        public async Task<IActionResult> Create()
        {
            var vm = new EquipmentCreateEditViewModel()
            {
                EquipmentTypeSelectList = new SelectList(
                   
                    await _bll.EquipmentTypes.AllAsync(),
                    nameof(BLL.App.DTO.EquipmentType.Id), 
                    nameof(BLL.App.DTO.EquipmentType.Name)),
                FarmSelectList = new SelectList(
                    
                    await _bll.Farms.AllForUserAsync(User.GetUserId()),
                    nameof(BLL.App.DTO.Farm.Id), 
                    nameof(BLL.App.DTO.Farm.Name))
            };
            return View(vm);

        }

        // POST: Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EquipmentCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.Equipments.Add(vm.Equipment);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            vm.EquipmentTypeSelectList = new SelectList(
                await _bll.EquipmentTypes.AllAsync(),
                nameof(BLL.App.DTO.EquipmentType.Id),
                nameof(BLL.App.DTO.EquipmentType.Name),
                vm.Equipment.EquipmentTypeId);
            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name), 
                vm.Equipment.FarmId);

            return View(vm);

        }
        
        

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _bll.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            var vm = new EquipmentCreateEditViewModel();
            vm.Equipment = equipment;
            vm.EquipmentTypeSelectList = new SelectList(
                await _bll.EquipmentTypes.AllAsync(),
                nameof(BLL.App.DTO.EquipmentType.Id),
                nameof(BLL.App.DTO.EquipmentType.Name),
                vm.Equipment.EquipmentTypeId);
            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name), 
                vm.Equipment.EquipmentTypeId);

            
            return View(vm);

        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EquipmentCreateEditViewModel vm)
        {
            if (id != vm.Equipment.Id)
            {
                return NotFound();
            }
            
            if (!await _bll.Equipments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            

            if (ModelState.IsValid)
            {
                _bll.Equipments.Update(vm.Equipment);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            vm.EquipmentTypeSelectList = new SelectList(
                await _bll.EquipmentTypes.AllAsync(),
                nameof(BLL.App.DTO.EquipmentType.Id),
                nameof(BLL.App.DTO.EquipmentType.Name),
                vm.Equipment.EquipmentTypeId);
            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name),
                vm.Equipment.EquipmentTypeId);

            return View(vm);

        }
        
        // GET: Equipments/Insatall/5
        public async Task<IActionResult> Install(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _bll.Equipments.FindAsync(id);
            var farm = await _bll.Farms.FindAsync(equipment.FarmId);
            var farmer = await _bll.Farmers.FindAsync(farm.FarmerId);
            
            if (equipment == null)
            {
                return NotFound();
            }
            var vm = new Install();
            vm.Equipment = equipment;
            vm.EquipmentTypeSelectList = new SelectList(
                await _bll.EquipmentTypes.AllAsync(),
                nameof(BLL.App.DTO.EquipmentType.Id),
                nameof(BLL.App.DTO.EquipmentType.Name),
                vm.Equipment.EquipmentTypeId);
            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name), 
                vm.Equipment.EquipmentTypeId);
            vm.Farmer = farmer;
            
            return View(vm);

        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Install(int id, Install vm)
        {
            if (id != vm.Equipment.Id)
            {
                return NotFound();
            }
            
            if (!await _bll.Equipments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            vm.Farmer.Score = vm.Farmer.Score + 5;
            if (ModelState.IsValid)
            {
                _bll.Farmers.Update(vm.Farmer);
                _bll.Equipments.Update(vm.Equipment);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            vm.EquipmentTypeSelectList = new SelectList(
                await _bll.EquipmentTypes.AllAsync(),
                nameof(BLL.App.DTO.EquipmentType.Id),
                nameof(BLL.App.DTO.EquipmentType.Name),
                vm.Equipment.EquipmentTypeId);
            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name),
                vm.Equipment.EquipmentTypeId);

            return View(vm);

        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _bll.Equipments.FindForUserAsync(id.Value, User.GetUserId());
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var equipment = await _bll.Equipments.FindForUserAsync(id, User.GetUserId());
            
            if (!await _bll.Equipments.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Equipments.Remove(id);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
    }
}
