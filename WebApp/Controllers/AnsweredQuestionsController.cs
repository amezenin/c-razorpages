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
    public class AnsweredQuestionsController : Controller
    {
        private readonly IAppBLL _bll;

        public AnsweredQuestionsController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: AnsweredQuestions
        public async Task<IActionResult> Index()
        {
            //TODO: how use DTO for user?
            //for registered user
            var answeredQuestions = await _bll.AnsweredQuestions.AllForUserAsync(User.GetUserId());
            
            //DTO can see all users
            //var answeredQuestions = await _bll.AnsweredQuestions.AllAsync();
            return View(answeredQuestions);
        }

        // GET: AnsweredQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answeredQuestion = await _bll.AnsweredQuestions.FindForUserAsync(id.Value, User.GetUserId());
            if (answeredQuestion == null)
            {
                return NotFound();
            }

            return View(answeredQuestion);
        }

        // GET: AnsweredQuestions/Create
        public async Task<IActionResult> Create()
        {
            var vm = new AnsweredQuestionCreateEditViewModel()
            {
                QuestionSelectList = new SelectList(
                    await _bll.Questions.AllAsync(),
                    nameof(BLL.App.DTO.Question.Id), 
                    nameof(BLL.App.DTO.Question.QuestionText)),
                FarmerSelectList = new SelectList(
                    await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                    nameof(BLL.App.DTO.Farmer.Id), 
                    nameof(BLL.App.DTO.Farmer.Firstname))
            };
            return View(vm);
        }

        // POST: AnsweredQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnsweredQuestionCreateEditViewModel vm)        {
            if (ModelState.IsValid)
            {
                _bll.AnsweredQuestions.Add(vm.AnsweredQuestion);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(BLL.App.DTO.Question.Id),
                nameof(BLL.App.DTO.Question.QuestionText),
                vm.AnsweredQuestion.QuestionId);

            vm.FarmerSelectList = new SelectList(
                await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farmer.Id),
                nameof(BLL.App.DTO.Farmer.Firstname), 
                vm.AnsweredQuestion.FarmerId);

            return View(vm);
        }

        // GET: AnsweredQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answeredQuestion = await _bll.AnsweredQuestions.FindAsync(id);
            if (answeredQuestion == null)
            {
                return NotFound();
            }
            var vm = new AnsweredQuestionCreateEditViewModel();
            vm.AnsweredQuestion = answeredQuestion;
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(BLL.App.DTO.Question.Id),
                nameof(BLL.App.DTO.Question.QuestionText),
                vm.AnsweredQuestion.QuestionId);
            vm.FarmerSelectList = new SelectList(
                await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farmer.Id),
                nameof(BLL.App.DTO.Farmer.Firstname), 
                vm.AnsweredQuestion.FarmerId);

            
            return View(vm);
        }

        // POST: AnsweredQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnsweredQuestionCreateEditViewModel vm)        {
            if (id != vm.AnsweredQuestion.Id)
            {
                return NotFound();
            }
            
            //just controll. Under other user do not give Id :)
            if (!await _bll.AnsweredQuestions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.AnsweredQuestions.Update(vm.AnsweredQuestion);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(BLL.App.DTO.Question.Id),
                nameof(BLL.App.DTO.Question.QuestionText),
                vm.AnsweredQuestion.QuestionId);
            vm.FarmerSelectList = new SelectList(
                await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                nameof(BLL.App.DTO.Farmer.Id),
                nameof(BLL.App.DTO.Farmer.Firstname), 
                vm.AnsweredQuestion.FarmerId);

            
            return View(vm);
        }

        // GET: AnsweredQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answeredQuestion = await _bll.AnsweredQuestions.FindForUserAsync(id.Value, User.GetUserId());
            if (answeredQuestion == null)
            {
                return NotFound();
            }

            return View(answeredQuestion);
        }

        // POST: AnsweredQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await _bll.AnsweredQuestions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }


            _bll.AnsweredQuestions.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
