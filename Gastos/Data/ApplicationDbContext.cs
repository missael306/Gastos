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
            Icon sales = new Icon("fas fa-chart-bar", 41);
            Icon business = new Icon("fas fa-chart-pie", 42);
            Icon investment = new Icon("fas fa-chart-line", 43);

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
            lstIcons.Add(sales);
            lstIcons.Add(business);
            lstIcons.Add(investment);

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
            category1.IconID = entertaiment.IconID;
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

            Category category7 = new Category();
            category7.CategoryID = 7;
            category7.Name = "Amazon";
            category7.RegisterDate = DateTime.Now;
            category7.IconID = 8;
            category7.Active = true;
            category7.TypeTransactionID = outlay.TypeTransactionID;

            Category category8 = new Category();
            category8.CategoryID = 8;
            category8.Name = "Bebé";
            category8.RegisterDate = DateTime.Now;
            category8.IconID = 10;
            category8.Active = true;
            category8.TypeTransactionID = outlay.TypeTransactionID;

            Category category9 = new Category();
            category9.CategoryID = 9;
            category9.Name = "Emergencia";
            category9.RegisterDate = DateTime.Now;
            category9.IconID = 12;
            category9.Active = true;
            category9.TypeTransactionID = outlay.TypeTransactionID;

            Category category10 = new Category();
            category10.CategoryID = 10;
            category10.Name = "Transporte";
            category10.RegisterDate = DateTime.Now;
            category10.IconID = 13;
            category10.Active = true;
            category10.TypeTransactionID = outlay.TypeTransactionID;
           

            Category category11 = new Category();
            category11.CategoryID = 11;
            category11.Name = "Gasolina";
            category11.RegisterDate = DateTime.Now;
            category11.IconID = 14;
            category11.Active = true;
            category11.TypeTransactionID = outlay.TypeTransactionID;

            Category category12 = new Category();
            category12.CategoryID = 12;
            category12.Name = "Taxi";
            category12.RegisterDate = DateTime.Now;
            category12.IconID = 15;
            category12.Active = true;
            category12.TypeTransactionID = outlay.TypeTransactionID;

            Category category13 = new Category();
            category13.CategoryID = 13;
            category13.Name = "Café";
            category13.RegisterDate = DateTime.Now;
            category13.IconID = 16;
            category13.Active = true;
            category13.TypeTransactionID = outlay.TypeTransactionID;

            Category category14 = new Category();
            category14.CategoryID = 14;
            category14.Name = "Alcohol";
            category14.RegisterDate = DateTime.Now;
            category14.IconID = 17;
            category14.Active = true;
            category14.TypeTransactionID = outlay.TypeTransactionID;
            
            Category category15 = new Category();
            category15.CategoryID = 15;
            category15.Name = "Cumpleaños";
            category15.RegisterDate = DateTime.Now;
            category15.IconID = 18;
            category15.Active = true;
            category15.TypeTransactionID = outlay.TypeTransactionID;            

            Category category16 = new Category();
            category16.CategoryID = 16;
            category16.Name = "Ropa";
            category16.RegisterDate = DateTime.Now;
            category16.IconID = 19;
            category16.Active = true;
            category16.TypeTransactionID = outlay.TypeTransactionID;            

            Category category17 = new Category();
            category17.CategoryID = 17;
            category17.Name = "Wifi";
            category17.RegisterDate = DateTime.Now;
            category17.IconID = 20;
            category17.Active = true;
            category17.TypeTransactionID = outlay.TypeTransactionID;

            Category category18 = new Category();
            category18.CategoryID = 18;
            category18.Name = "Tv";
            category18.RegisterDate = DateTime.Now;
            category18.IconID = 21;
            category18.Active = true;
            category18.TypeTransactionID = outlay.TypeTransactionID;

            Category category19 = new Category();
            category19.CategoryID = 19;
            category19.Name = "Computación";
            category19.RegisterDate = DateTime.Now;
            category19.IconID = 22;
            category19.Active = true;
            category19.TypeTransactionID = outlay.TypeTransactionID;

            Category category20 = new Category();
            category20.CategoryID = 20;
            category20.Name = "Honorarios";
            category20.RegisterDate = DateTime.Now;
            category20.IconID = 23;
            category20.Active = true;
            category20.TypeTransactionID = deposit.TypeTransactionID;

            Category category21 = new Category();
            category21.CategoryID = 21;
            category21.Name = "TDC";
            category21.RegisterDate = DateTime.Now;
            category21.IconID = 26;
            category21.Active = true;
            category21.TypeTransactionID = outlay.TypeTransactionID;

            Category category22 = new Category();
            category22.CategoryID = 22;
            category22.Name = "Préstamo";
            category22.RegisterDate = DateTime.Now;
            category22.IconID = 34;
            category22.Active = true;
            category22.TypeTransactionID = deposit.TypeTransactionID;

            Category category23 = new Category();
            category23.CategoryID = 23;
            category23.Name = "Gimnasio";
            category23.RegisterDate = DateTime.Now;
            category23.IconID = 38;
            category23.Active = true;
            category23.TypeTransactionID = outlay.TypeTransactionID;

            Category category24 = new Category();
            category24.CategoryID = 24;
            category24.Name = "Accesorios";
            category24.RegisterDate = DateTime.Now;
            category24.IconID = 40;
            category24.Active = true;
            category24.TypeTransactionID = outlay.TypeTransactionID;

            Category category25 = new Category();
            category25.CategoryID = 25;
            category25.Name = "Ventas";
            category25.RegisterDate = DateTime.Now;
            category25.IconID = sales.IconID;
            category25.Active = true;
            category25.TypeTransactionID = deposit.TypeTransactionID;

            Category category26 = new Category();
            category26.CategoryID = 26;
            category26.Name = "Rendimientos";
            category26.RegisterDate = DateTime.Now;
            category26.IconID = business.IconID;
            category26.Active = true;
            category26.TypeTransactionID = deposit.TypeTransactionID;

            Category category27 = new Category();
            category27.CategoryID = 27;
            category27.Name = "Inversión";
            category27.RegisterDate = DateTime.Now;
            category27.IconID = investment.IconID;
            category27.Active = true;
            category27.TypeTransactionID = deposit.TypeTransactionID;


            List<Category> lstCategories = new List<Category>();
            lstCategories.Add(category1);
            lstCategories.Add(category2);
            lstCategories.Add(category3);
            lstCategories.Add(category4);
            lstCategories.Add(category5);
            lstCategories.Add(category6);
            lstCategories.Add(category7);
            lstCategories.Add(category8);
            lstCategories.Add(category9);
            lstCategories.Add(category10);
            lstCategories.Add(category11);
            lstCategories.Add(category12);
            lstCategories.Add(category13);
            lstCategories.Add(category14);
            lstCategories.Add(category15);
            lstCategories.Add(category16);
            lstCategories.Add(category17);
            lstCategories.Add(category18);
            lstCategories.Add(category19);
            lstCategories.Add(category20);
            lstCategories.Add(category21);
            lstCategories.Add(category22);
            lstCategories.Add(category23);
            lstCategories.Add(category24);
            lstCategories.Add(category25);
            lstCategories.Add(category26);
            lstCategories.Add(category27);            
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
