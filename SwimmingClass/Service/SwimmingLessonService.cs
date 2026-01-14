using Microsoft.EntityFrameworkCore;
using SwimmingClass.Data;
using SwimmingClass.Model;

namespace SwimmingClass.Services
{
    public class SwimmingLessonService
    {
        private readonly ApplicationDbContext _context;

        public SwimmingLessonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SwimmingLesson>> GetAllAsync()
        {
            return await _context.SwimmingLessons
                                 .Include(s => s.Instructor)
                                 .ToListAsync();
        }

        public async Task<SwimmingLesson> GetByIdAsync(int id)
        {
            return await _context.SwimmingLessons
                                 .Include(s => s.Instructor)
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(SwimmingLesson lesson)
        {
            _context.SwimmingLessons.Add(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SwimmingLesson lesson)
        {
            _context.SwimmingLessons.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lesson = await _context.SwimmingLessons.FindAsync(id);
            if (lesson != null)
            {
                _context.SwimmingLessons.Remove(lesson);
                await _context.SaveChangesAsync();
            }
        }
    }
}
