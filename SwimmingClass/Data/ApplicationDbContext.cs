using Microsoft.EntityFrameworkCore;
using SwimmingClass.Model;
using System.Collections.Generic;

namespace SwimmingClass.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Adicione seus DbSets aqui
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<SwimmingLesson> SwimmingLessons { get; set; }
    }
}