using Microsoft.AspNetCore.Mvc;
using SwimmingClass.Model;
using SwimmingClass.Services;
using System.Linq;
using System.Threading.Tasks;


namespace SwimmingClass.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: /Student
        public async Task<IActionResult> Index()
        {
            try
            {
                var students = await _studentService.GetAllAsync();
                return View(students);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        // GET: /Student/CreateForm
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddAsync(student);
                return RedirectToAction(nameof(Index));
            }

            // Se o modelo não for válido, volta pro formulário
            return View(student);
        }

        // GET: /Student/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: /Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest(); // evita inconsistência de IDs
            }

            if (ModelState.IsValid)
            {
                await _studentService.UpdateAsync(student);
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // GET: /Student/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}