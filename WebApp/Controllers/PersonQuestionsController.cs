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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Versioning;
using WebApp.Models;
using Solution = Microsoft.CodeAnalysis.Solution;

namespace WebApp.Controllers
{
    [Authorize]
    public class PersonQuestionsController : Controller
    {
        private readonly IAppBLL _bll;
        public PersonQuestionsController( IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: PersonQuestions
        public async Task<IActionResult> Index()
        {
            var personQuestion = await _bll.PersonQuestions.AllForUserAsync(User.GetUserId());
            return View(personQuestion);
        }

        // GET: PersonQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personQuestion = await _bll.PersonQuestions.FindForUserAsync(id.Value, User.GetUserId());
            if (personQuestion == null)
            {
                return NotFound();
            }

            return View(personQuestion);
        }
        
        public async Task<IActionResult> Vasta(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pq = await _bll.PersonQuestions.FindForUserAsync(id.Value, User.GetUserId());
            if (pq == null)
            {
                return NotFound();
            }
            
            
            var farmer = await _bll.Farmers.FindAsync(pq.FarmerId);
            var question = await _bll.Questions.FindAsync(pq.QuestionId);
            var solution = await _bll.Solutions.AllAsync();
            var sol = solution.FirstOrDefault(x => x.QuestionId == question.Id);
            var answer = await _bll.Answers.AllAsync();
            var ans = answer.FirstOrDefault(x => x.QuestionId == question.Id);
            
            
            
            var vm = new PersonQuestionVastaViewModel();
            vm.PersonQuestion = pq;
            vm.Solution = sol;
            vm.Answer = ans;
            vm.Farmer = farmer;
            vm.Question = question;
           

            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Vasta(int id, PersonQuestionVastaViewModel vm)        {
           /* if (id != vm.PersonQuestion.Id)
            {
                return NotFound();
            }*/
            
            //just controll. Under other user FarmSelectList do not give Id :)
            /* if (!await _bll.Tanks.BelongsToUserAsync(id, User.GetUserId()))
             {
                 return NotFound();
             }*/

            
            var solution = await _bll.Solutions.FindAsync(vm.Solution.Id);
            
            var AQ = await _bll.AnsweredQuestions.AllAsync();
            var ansQ = AQ.FirstOrDefault(x => x.QuestionId == vm.Question.Id && x.FarmerId == vm.Farmer.Id);

                var answeredQuestion = new BLL.App.DTO.AnsweredQuestion()
                            {
                                Value = true,
                                FarmerId = vm.Farmer.Id,
                                QuestionId = vm.Question.Id
                
                            };
          
            //var sol = solution.FirstOrDefault(x => x.QuestionId == question.Id);

            if (vm.Solution.SolutionValue != solution.SolutionValue)
            {
                return Content("Vale vastus");
            }
            
            vm.Farmer.Score = vm.Farmer.Score + vm.Question.QuestionGivesScore;
            

            if (ModelState.IsValid)
            {
                if (ansQ == null)
                {
                    _bll.AnsweredQuestions.Add(answeredQuestion);
                }

                _bll.Farmers.Update(vm.Farmer);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            

           
            return View(vm);

        }

        // GET: PersonQuestions/Create
        public async Task<IActionResult> Create()
        {
            var vm = new PersonQuestionCreateEditViewModel()
            {
                QuestionSelectList = new SelectList(
                    await _bll.Questions.AllAsync(),
                    nameof(Question.Id), 
                    nameof(Question.QuestionText)),
                FarmerSelectList = new SelectList(
                    await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                    nameof(Farmer.Id), 
                    nameof(Farmer.Firstname))
            };
            return View(vm);
        }

        // POST: PersonQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonQuestionCreateEditViewModel vm)       
        {
            
            if (ModelState.IsValid)
            {
                _bll.PersonQuestions.Add(vm.PersonQuestion);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(Question.Id),
                nameof(Question.QuestionText),
                vm.PersonQuestion.QuestionId);

            vm.FarmerSelectList = new SelectList(
                await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                nameof(Farmer.Id),
                nameof(Farmer.Firstname), 
                vm.PersonQuestion.FarmerId);
            
            return View(vm);
        }

        // GET: PersonQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personQuestion = await _bll.PersonQuestions.FindAsync(id);
            if (personQuestion == null)
            {
                return NotFound();
            }
            var vm = new PersonQuestionCreateEditViewModel();
            vm.PersonQuestion = personQuestion;
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(Question.Id),
                nameof(Question.QuestionText),
                vm.PersonQuestion.QuestionId);
            vm.FarmerSelectList = new SelectList(
                await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                nameof(Farmer.Id),
                nameof(Farmer.Firstname), 
                vm.PersonQuestion.FarmerId);

            
            return View(vm);
        }

        // POST: PersonQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PersonQuestionCreateEditViewModel vm)
        {
            if (id != vm.PersonQuestion.Id)
            {
                return NotFound();
            }
            
            //just controll. Under other user do not give Id :)
            if (!await _bll.PersonQuestions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.PersonQuestions.Update(vm.PersonQuestion);
                await _bll.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            vm.QuestionSelectList = new SelectList(
                await _bll.Questions.AllAsync(),
                nameof(Question.Id),
                nameof(Question.QuestionText),
                vm.PersonQuestion.QuestionId);
            vm.FarmerSelectList = new SelectList(
                await _bll.Farmers.AllForUserAsync(User.GetUserId()),
                nameof(Farmer.Id),
                nameof(Farmer.Firstname), 
                vm.PersonQuestion.FarmerId);

            
            return View(vm);
        }

        // GET: PersonQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personQuestion = await _bll.PersonQuestions.FindForUserAsync(id.Value, User.GetUserId());
            if (personQuestion == null)
            {
                return NotFound();
            }

            return View(personQuestion);
        }

        // POST: PersonQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await _bll.PersonQuestions.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }


            _bll.PersonQuestions.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
