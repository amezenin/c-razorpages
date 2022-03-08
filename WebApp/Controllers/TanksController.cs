using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Schema;
using WebApp.Models;
using Equipment = BLL.App.DTO.Equipment;
using Farm = BLL.App.DTO.Farm;
using Tank = BLL.App.DTO.Tank;

namespace WebApp.Controllers
{
    [Authorize]
    public class TanksController : Controller
    {
        private readonly IAppBLL _bll;

        public TanksController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: Tanks
        public async Task<IActionResult> Index()
        {
            
            //for registered user
           //var tanks = await _bll.Tanks.AllForUserAsync(User.GetUserId());
           
           var tanks2 = await _bll.Tanks.GetAllWithBiomassAsync(User.GetUserId());
           return View(tanks2);
           
          

        }

        // GET: Tanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _bll.Tanks.FindForUserAsync(id.Value, User.GetUserId());
            
            if (tank == null)
            {
                return NotFound();
            }

            return View(tank);
        }
        
      

        // GET: Tanks/Create
        public async Task<IActionResult> Create()
        {
            var vm = new TankCreateEditViewModel()
            {
                FishTypeSelectList = new SelectList(
                    await _bll.FishTypes.AllAsync(),
                    nameof(BLL.App.DTO.FishType.Id), 
                    nameof(BLL.App.DTO.FishType.Species)),
                FarmSelectList = new SelectList(
                    await _bll.Farms.AllForUserAsync(User.GetUserId()),
                    nameof(BLL.App.DTO.Farm.Id), 
                    nameof(BLL.App.DTO.Farm.Name))
            };
            return View(vm);

        }

        // POST: Tanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TankCreateEditViewModel vm)        {
            if (ModelState.IsValid)
            {
                _bll.Tanks.Add(vm.Tank);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            vm.FishTypeSelectList = new SelectList(
                await _bll.FishTypes.AllAsync(),
                nameof(BLL.App.DTO.FishType.Id),
                nameof(BLL.App.DTO.FishType.Species),
                vm.Tank.FishTypeId);

            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name), 
                vm.Tank.FarmId);

            return View(vm);

        }

        // GET: Tanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _bll.Tanks.FindAsync(id);
            if (tank == null)
            {
                return NotFound();
            }
            var vm = new TankCreateEditViewModel();
            vm.Tank = tank;
            vm.FishTypeSelectList = new SelectList(
                await _bll.FishTypes.AllAsync(),
                nameof(BLL.App.DTO.FishType.Id),
                nameof(BLL.App.DTO.FishType.Species),
                vm.Tank.FishTypeId);
            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name), 
                vm.Tank.FarmId);

            
            return View(vm);

        }
        
        

        // POST: Tanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TankCreateEditViewModel vm)        {
            if (id != vm.Tank.Id)
            {
                return NotFound();
            }
            
            //just controll. Under other user FarmSelectList do not give Id :)
            if (!await _bll.Tanks.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            

            if (ModelState.IsValid)
            {
                
                _bll.Tanks.Update(vm.Tank);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            vm.FishTypeSelectList = new SelectList(
                await _bll.FishTypes.AllAsync(),
                nameof(BLL.App.DTO.FishType.Id),
                nameof(BLL.App.DTO.FishType.Species),
                vm.Tank.FishTypeId);
            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name), 
                vm.Tank.FarmId);

            return View(vm);

        }
        
       
        
        // GET: Tanks/Feed/5
        public async Task<IActionResult> Feed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _bll.Tanks.FindAsync(id);
            
            
            if (tank == null)
            {
                return NotFound();
            }
            //for bind calculated data from DTO by ID
            var tankDTO = await _bll.Tanks.GetTankWithBiomassAsync(tank.Id, User.GetUserId());
            
            var farmer = await _bll.Farmers.FindAsync(tankDTO.Farm.FarmerId);
            
            var vm = new TankFeedViewModel();
            vm.Tank = tank;
            
            vm.FishTypeSelectList = new SelectList(
                await _bll.FishTypes.AllAsync(),
                nameof(BLL.App.DTO.FishType.Id),
                nameof(BLL.App.DTO.FishType.Species),
                vm.Tank.FishTypeId);
            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name), 
                vm.Tank.FarmId);
            vm.TankDTO = tankDTO;
            vm.Farmer = farmer;
            

            
            return View(vm);

        }
        
        

        // POST: Tanks/Feed/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Feed(int id, TankFeedViewModel vm)        {
            if (id != vm.Tank.Id)
            {
                return NotFound();
            }
            
            //just controll. Under other user FarmSelectList do not give Id :)
           /* if (!await _bll.Tanks.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }*/

            //var tank = await _bll.Tanks.FindAsync(id);
            var tankDTO = await _bll.Tanks.GetTankWithBiomassAsync(vm.Tank.Id, User.GetUserId());

            

            
            if (vm.TankDTO.NewAverage != tankDTO.NewAverage || 
                vm.TankDTO.NewBiomass != tankDTO.NewBiomass ||
                vm.TankDTO.FeedKg != tankDTO.FeedKg)
            {
                return NotFound();
            }

            vm.Tank.AverageMass = Convert.ToSingle(tankDTO.NewAverage);
            vm.Farmer.Score = vm.Farmer.Score + 5;

            
            
            if (ModelState.IsValid)
            {
                
                
                _bll.Tanks.Update(vm.Tank);
                _bll.Farmers.Update(vm.Farmer);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            vm.FishTypeSelectList = new SelectList(
                await _bll.FishTypes.AllAsync(),
                nameof(BLL.App.DTO.FishType.Id),
                nameof(BLL.App.DTO.FishType.Species),
                vm.Tank.FishTypeId);
            vm.FarmSelectList = new SelectList(
                await _bll.Farms.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farm.Id),
                nameof(BLL.App.DTO.Farm.Name), 
                vm.Tank.FarmId);
           
           
            return View(vm);

        }

        // GET: Tanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _bll.Tanks.FindForUserAsync(id.Value, User.GetUserId());
            if (tank == null)
            {
                return NotFound();
            }

            return View(tank);
        }

        // POST: Tanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var tank = await _bll.Tanks.FindForUserAsync(id, User.GetUserId());
            
            if (!await _bll.Tanks.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }


            _bll.Tanks.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        
    }
}
