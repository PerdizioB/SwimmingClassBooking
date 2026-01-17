using Microsoft.AspNetCore.Mvc;
using SwimmingClass.Model;
using SwimmingClass.Services;

namespace SwimmingClass.Controllers
{
    public class InstructorController : Controller
    {

        private readonly InstructorService _instructorService;

        public InstructorController(InstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        // GET: /Instructor
        public async Task<IActionResult> Index()
        {
            var instructors = await _instructorService.GetAllAsync();
            return View(instructors);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instructor instructor)
        {
            if (!ModelState.IsValid) return View(instructor);
            await _instructorService.AddAsync(instructor);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Instructor instructor)
        {
            if (!ModelState.IsValid) return View(instructor);
            await _instructorService.UpdateAsync(instructor);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _instructorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
