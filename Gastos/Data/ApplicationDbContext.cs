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

            #region Create data                             
            Icon entertaiment = new Icon("fas fa-glass-cheers", 1);
            Icon healt = new Icon("fas fa-hospital", 2);
            Icon salary = new Icon("fas fa-wallet", 3);
            Icon car = new Icon("fas fa-car", 4);
            Icon house = new Icon("fas fa-house-user", 5);
            Icon food = new Icon("fas fa-utensils", 6);
            List<Icon> lstIcons = new List<Icon>() {               
                new Icon("fab fa-airbnb", 7),
                new Icon("fab fa-amazon", 8),
                new Icon("fab fa-apple", 9),
                new Icon("fas fa-baby", 10),
                new Icon("fas fa-bone", 11),
                new Icon("fas fa-ambulance", 12),
                new Icon("fas fa-bus-alt", 13),
                new Icon("fas fa-gas-pump", 14),
                new Icon("fas fa-taxi", 15),
                new Icon("fas fa-coffee", 16),
                new Icon("fas fa-cocktail", 17),
                new Icon("fas fa-birthday-cake", 18),
                new Icon("fas fa-tshirt", 19),
                new Icon("fas fa-wifi", 20),
                new Icon("fas fa-tv", 21),
                new Icon("fas fa-laptop", 22),
                new Icon("fas fa-money-bill-wave", 23),
                new Icon("fas fa-dollar-sign", 24),
                new Icon("fas fa-graduation-cap", 25),
                new Icon("fas fa-credit-card", 26),
                new Icon("fas fa-heartbeat", 27),
                new Icon("fas fa-bone", 28),
                new Icon("fas fa-pizza-slice", 29),
                new Icon("fas fa-dice", 30),
                new Icon("fab fa-playstation", 31),
                new Icon("fab fa-steam", 32),
                new Icon("fab fa-xbox", 33),
                new Icon("fas fa-hand-holding-usd", 34),
                new Icon("fas fa-ambulance", 35),
                new Icon("far fa-hospital", 36),
                new Icon("fas fa-gift", 37),
                new Icon("fas fa-dumbbell", 38),
                new Icon("fas fa-house-user", 39),
                new Icon("fas fa-headphones", 40)
            };

            lstIcons.Add(entertaiment);
            lstIcons.Add(healt);
            lstIcons.Add(salary);
            lstIcons.Add(car);
            lstIcons.Add(house);
            lstIcons.Add(food);

            TypeTransaction outlay = new TypeTransaction();
            outlay.TypeTransactionID = 1;
            outlay.Name = "Gasto";

            TypeTransaction deposit = new TypeTransaction();
            deposit.TypeTransactionID = 2;
            deposit.Name = "Ingreso";

            List<TypeTransaction> lstTypeTransaction = new List<TypeTransaction>();
            lstTypeTransaction.Add(outlay);
            lstTypeTransaction.Add(deposit);

            Category category1 = new Category();
            category1.CategoryID = 1;
            category1.Name = "Entretenimiento";
            category1.RegisterDate = DateTime.Now;
            category1.IconID = 1;
            category1.Active = true;
            category1.TypeTransactionID = outlay.TypeTransactionID;

            Category category2 = new Category();
            category2.CategoryID = 2;
            category2.Name = "Salud";
            category2.RegisterDate = DateTime.Now;
            category2.IconID = healt.IconID;
            category2.Active = true;
            category2.TypeTransactionID = outlay.TypeTransactionID;

            Category category3 = new Category();
            category3.CategoryID = 3;
            category3.Name = "Salario";
            category3.RegisterDate = DateTime.Now;
            category3.IconID = salary.IconID;
            category3.Active = true;
            category3.TypeTransactionID = deposit.TypeTransactionID;

            Category category4 = new Category();
            category4.CategoryID = 4;
            category4.Name = "Automóvil";
            category4.RegisterDate = DateTime.Now;
            category4.IconID = car.IconID;
            category4.Active = true;
            category4.TypeTransactionID = outlay.TypeTransactionID;

            Category category5 = new Category();
            category5.CategoryID = 5;
            category5.Name = "Casa";
            category5.RegisterDate = DateTime.Now;
            category5.IconID = house.IconID;
            category5.Active = true;
            category5.TypeTransactionID = outlay.TypeTransactionID;

            Category category6 = new Category();
            category6.CategoryID = 6;
            category6.Name = "Comida";
            category6.RegisterDate = DateTime.Now;
            category6.IconID = food.IconID;
            category6.Active = true;
            category6.TypeTransactionID = outlay.TypeTransactionID;

            List<Category> lstCategories = new List<Category>();
            lstCategories.Add(category1);
            lstCategories.Add(category2);
            lstCategories.Add(category3);
            lstCategories.Add(category4);
            lstCategories.Add(category5);
            lstCategories.Add(category6);
            #endregion

            #region extra configurations            
            modelBuilder.Entity<Transaction>().HasOne(t => t.TypeTransaction).WithMany(x => x.Transactions).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transaction>().Property(t => t.Value).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Icon>().Property(i => i.RegisterDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Icon>().Property(i => i.Active).HasDefaultValue(true);
            modelBuilder.Entity<Icon>().Property(i => i.IconID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>().Property(c => c.Active).HasDefaultValue(true);
            modelBuilder.Entity<Category>().Property(c => c.RegisterDate).HasDefaultValueSql("GETDATE()");
            #endregion

            #region set the tables            
            modelBuilder.Entity<Icon>().HasData(lstIcons);
            modelBuilder.Entity<TypeTransaction>().HasData(lstTypeTransaction);
            modelBuilder.Entity<Category>().HasData(lstCategories);
            #endregion
        }
    }
}
