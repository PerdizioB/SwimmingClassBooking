using Microsoft.AspNetCore.Mvc;
using SwimmingClass.Model;
using SwimmingClass.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SwimmingClass.Controllers
{
    public class SwimmingLessonController : Controller
    {
        private readonly SwimmingLessonService _swimmingLessonService;

        public SwimmingLessonController(SwimmingLessonService swimmingLessonService)
        {
            _swimmingLessonService = swimmingLessonService;
        }

        // GET: /SwimmingLesson
        public async Task<IActionResult> Index()
        {
            var lessons = await _swimmingLessonService.GetAllAsync();
            return View(lessons);
        }

        // GET: /SwimmingLesson/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var lesson = await _swimmingLessonService.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            return View(lesson);
        }

        // GET: /SwimmingLesson/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /SwimmingLesson/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SwimmingLesson lesson)
        {
            if (!ModelState.IsValid) return View(lesson);

            await _swimmingLessonService.AddAsync(lesson);
            return RedirectToAction(nameof(Index));
        }

        // GET: /SwimmingLesson/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var lesson = await _swimmingLessonService.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            return View(lesson);
        }

        // POST: /SwimmingLesson/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SwimmingLesson lesson)
        {
            if (id != lesson.Id) return BadRequest();
            if (!ModelState.IsValid) return View(lesson);

            await _swimmingLessonService.UpdateAsync(lesson);
            return RedirectToAction(nameof(Index));
        }

        // GET: /SwimmingLesson/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var lesson = await _swimmingLessonService.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            return View(lesson);
        }

        // POST: /SwimmingLesson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _swimmingLessonService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}