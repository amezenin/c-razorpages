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
    public class SolutionsController : Controller
    {
        private readonly IAppBLL _bll;

        public SolutionsController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: Solutions
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Solutions.AllAsync());
           /* var solution = await _bll.Solutions.AllForUserAsync(User.GetUserId());
            return View(solution);*/
           
           
        }

        // GET: Solutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var fishType = await _context.FishTypes
                .FirstOrDefaultAsync(m => m.Id == id);*/
            
            var solution = await _bll.Solutions.FindAsync(id);
            if (solution == null)
            {
                return NotFound();
            }

            return View(solution);
        }

        // GET: Solutions/Create
        public async Task<IActionResult> Create()
        {
            var vm = new SolutionCreateEditViewModel()
            {
                QuestionSelectList = new SelectList(
                    
                    await _bll.Questions.AllAsync(),
                    nameof(Question.Id), 
                    nameof(Question.QuestionText))
                
            };
            return View(vm);

        }

        // POST: Solutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SolutionCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _bll.Solutions.Add(vm.Solution);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(Question.Id),
                nameof(Question.QuestionText),
                vm.Solution.QuestionId);
            
            return View(vm);

        }

        // GET: Solutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //maybe that
            //var farm = await _bll.Farms.FindForUserAsync(id.Value, User.GetUserId());
            var solution = await _bll.Solutions.FindAsync(id);
            if (solution == null)
            {
                return NotFound();
            }

            if (solution == null)
            {
                return NotFound();
            }
            var vm = new SolutionCreateEditViewModel();
            vm.Solution = solution;
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(Question.Id),
                nameof(Question.QuestionText),
                vm.Solution.QuestionId);

            
            return View(vm);

        }

        // POST: Solutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, SolutionCreateEditViewModel vm)
        {
            if (id != vm.Solution.Id)
            {
                return NotFound();
            }
            
            ////edit after create dosnt work (not found), because I dint give UserId for questions - solutions
            // check for the ownership - is this Person record really belonging to logged in user.
            /*if (! await _bll.Solutions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }*/


            if (ModelState.IsValid)
            {
                _bll.Solutions.Update(vm.Solution);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(Question.Id),
                nameof(Question.QuestionText),
                vm.Solution.QuestionId);

            return View(vm);

        }

        // GET: Solutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solution = await _bll.Solutions.FindAsync(id.Value);
            if (solution == null)
            {
                return NotFound();
            }

            return View(solution);
        }

        // POST: Solutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*if (!await _bll.Solutions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }*/

            _bll.Solutions.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        
    }
}
