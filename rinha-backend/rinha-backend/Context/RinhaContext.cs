using System;
using Microsoft.EntityFrameworkCore;
using rinha_backend.Entity;

namespace rinha_backend.Context
{
    public class RinhaContext : DbContext
    {
        public RinhaContext(DbContextOptions<RinhaContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pessoa>()
            //.Property(e => e.Stack)
            //.HasConversion(
            //    stack => string.Join(',', stack),
            //    stack => stack.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}

