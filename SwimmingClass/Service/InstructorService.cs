using Microsoft.EntityFrameworkCore;
using SwimmingClass.Data;
using SwimmingClass.Model;

namespace SwimmingClass.Services
{
    public class InstructorService
    {
        private readonly ApplicationDbContext _context;

        public InstructorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Instructor>> GetAllAsync()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _context.Instructors.FindAsync(id);
        }

        public async Task AddAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
