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
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class AnswersController : Controller
    {
        private readonly IAppBLL _bll;

        public AnswersController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Answers.AllAsync());
            /*var answer = await _bll.Answers.AllForUserAsync(User.GetUserId());
            return View(answer);*/
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var fishType = await _context.FishTypes
                .FirstOrDefaultAsync(m => m.Id == id);*/
            
            var answer = await _bll.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // GET: Answers/Create
        public async Task<IActionResult> Create()
        {
            var vm = new AnswerCreateEditViewModel()
            {
                QuestionSelectList = new SelectList(
                    
                    await _bll.Questions.AllAsync(),
                    nameof(Question.Id), 
                    nameof(Question.QuestionText))
                
            };
            return View(vm);
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnswerCreateEditViewModel vm)        {
            if (ModelState.IsValid)
            {
                _bll.Answers.Add(vm.Answer);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(Question.Id),
                nameof(Question.QuestionText),
                vm.Answer.QuestionId);
            
            return View(vm);
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _bll.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            var vm = new AnswerCreateEditViewModel();
            vm.Answer = answer;
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(Question.Id),
                nameof(Question.QuestionText),
                vm.Answer.QuestionId);

            
            return View(vm);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnswerCreateEditViewModel vm)        {
            if (id != vm.Answer.Id)
            {
                return NotFound();
            }
            
            //edit after create dosnt work (not found), because I dint give UserId for questions - answers
            // check for the ownership - is this Person record really belonging to logged in user.
            /*if (! await _bll.Answers.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                _bll.Answers.Update(vm.Answer);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(Question.Id),
                nameof(Question.QuestionText),
                vm.Answer.QuestionId);

            return View(vm);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _bll.Answers.FindAsync(id.Value);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*if (!await _bll.Answers.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }*/

            _bll.Answers.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
