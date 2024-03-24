using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        #region Base Library Entities to be added to DB
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; } 
        public DbSet<Town> Towns { get; set; }

        // Authentication Tables
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }

        // Others
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<SanctionType> sanctionTypes { get; set; }
        public DbSet<OverTime> OverTimes { get; set; }
        public DbSet<OverTimeType> OverTimesTypes { get; set; }
        public DbSet<Health> Healths { get; set; }
        #endregion
    }
}
