using System;
using System.Collections.Generic;
using System.Text;
using Gastos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Icon> Icons { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TypeTransaction> TypeTransactions { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region extra configurations            
            modelBuilder.Entity<Transaction>().HasOne(t => t.TypeTransaction).WithMany(x => x.Transactions).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transaction>().Property(t => t.Value).HasColumnType("decimal(18,2)");            

            modelBuilder.Entity<Icon>().Property(i => i.RegisterDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Icon>().Property(i => i.Active).HasDefaultValue(true);
            modelBuilder.Entity<Icon>().Property(i => i.IconID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>().Property(c => c.Active).HasDefaultValue(true);
            modelBuilder.Entity<Category>().Property(c => c.RegisterDate).HasDefaultValueSql("GETDATE()");

            #endregion
        }
    }
}
