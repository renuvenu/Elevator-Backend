using ES.Model;
using Microsoft.EntityFrameworkCore;

namespace ES.DataAccess
{
    public class DbContextAccess: DbContext
    {
        public DbContextAccess(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<PersonDetailsInLift> PersonDetailsInLifts { get; set; }


    }
}
