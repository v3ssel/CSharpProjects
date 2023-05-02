// dotnet add package Microsoft.EntityFrameworkCore.Sqlite
// dotnet add package Microsoft.EntityFrameworkCore.Tools
// dotnet tool install --global dotnet-ef
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Data
{
    public class HabitDbContext : DbContext
    {
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitCheck> HabitChecks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=../HabitTracker.Data/habits.db");
        }

    }
}
