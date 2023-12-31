﻿using ES.Model;
using Microsoft.EntityFrameworkCore;

namespace ES.DataAccess
{
    public class DbContextAccess: DbContext
    {
        public DbContextAccess(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        
        public DbSet<PersonDetailsInLift> PersonDetailsInLifts { get; set; }
        public DbSet<LiftFunctionDetails> LiftFunctionDetail { get; set; }
        public DbSet<Floor> Floors { get; set; }

        public DbSet<Person> Persons { get; set; }

    }
}
