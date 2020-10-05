using Gastos.Data;
using Gastos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Gastos.Business
{
    public class HomeBusiness
    {
        #region Attributes
        private ApplicationDbContext _context;
        UserManager<IdentityUser> _userManager;
        #endregion

        #region Constructor
        public HomeBusiness(ApplicationDbContext context, UserManager<IdentityUser> UserManager)
        {
            _context = context;
            _userManager = UserManager;
        }
        #endregion 

        #region Methods        
        //-------------------   Catalogs
        public ICollection<Category> LstCategories()
        {
            //it gets all the categories without filter
            ICollection<Category> lstCategories = _context.Categories.Include(x => x.Icon).ToList();
            return lstCategories;
        }

        public ICollection<Category> LstCategories(int idTypeTransaccion)
        {
            //gets categories according to idTypeTransaccion
            ICollection<Category> lstCategories = _context.Categories.Where(x => x.TypeTransactionID == idTypeTransaccion).Include(x => x.Icon).ToList();
            return lstCategories;
        }

        public ICollection<Icon> LstIcons()
        {
            ICollection<Icon> lstIcons = _context.Icons.ToList();
            return lstIcons;
        }

        //-------------------   Add items
        public bool AddCategory(Category model)
        {
            bool result = false;
            try
            {
                _context.Categories.Add(model);
                result = (_context.SaveChanges() > 0) ? true : false;
            }
            catch (Exception ex)
            {
                //TODO: Guardar un log;
                string log = ex.Message;
            }
            return result;
        }

        public bool AddTrasaction(Transaction model)
        {
            bool result = false;
            try
            {
                model.Value = (model.TypeTransactionID == 1) ? (model.Value * -1) : model.Value;
                _context.Transactions.Add(model);
                result = (_context.SaveChanges() > 0) ? true : false;
            }
            catch (Exception ex)
            {
                //TODO: Guardar un log;
                string log = ex.Message;
            }
            return result;
        }

        //-------------------   Transactions
        public List<Transaction> LstTransactions()
        {
            //Type = 1 (Expense); Type = 2 (Deposit);
            List<Transaction> LstTransactions = new List<Transaction>();
            LstTransactions = _context.Transactions.ToList();
            return LstTransactions;
        }

        public List<Transaction> LstTransactions(int type)
        {
            //Return transactions per type 
            //Type = 1 (Expense); Type = 2 (Deposit);
            List<Transaction> LstTransactions = new List<Transaction>();
            LstTransactions = _context.Transactions.Where(x => x.TypeTransactionID == type).ToList();
            return LstTransactions;
        }

        public List<Transaction> LstTransactions(int type, DateTime start, DateTime end )
        {
            //Return transactions per type 
            //Type = 1 (Expense); Type = 2 (Deposit);            
            List<Transaction> LstTransactions = new List<Transaction>();
            LstTransactions = _context.Transactions
            .Where(x => x.TypeTransactionID == type && x.ActionDate >= start && x.ActionDate <= end )
            .Include(x => x.Category)
            .ToList();
            return LstTransactions;
        }

        public List<Expense> LstExpensesDay(DateTime start, DateTime end)
        {
            //Return the list of expenses in a day for the fullcalendar
            List<Expense> lstExpenses = new List<Expense>();
            for (DateTime fecha = start; fecha <= end; fecha = fecha.AddDays(1))
            {
                decimal expenses = LstTransactions(1, fecha, fecha).Sum(x => x.Value);
                decimal deposits = LstTransactions(2, fecha, fecha).Sum(x => x.Value);
                decimal balance = deposits + expenses;

                Expense expense = new Expense();
                expense.id = fecha.Day;
                expense.start = fecha.ToString("yyyy-MM-dd");
                expense.title = String.Format("{0:c}", balance);
                if (balance > 0)
                    expense.backgroundColor = "green";
                else if (balance < 0)
                    expense.backgroundColor = "red";
                else
                    expense.backgroundColor = "gray";
                lstExpenses.Add(expense);
            }
            return lstExpenses;
        }
        #endregion
    }
}
