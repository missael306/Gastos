using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Models
{
    public class Balance
    {
        //------------------------
        //It represent the difference between deposit and outlay       
        //------------------------              
        #region Attributes
        public decimal Deposit { get; set; }
        public decimal Expense { get; set; }
        public string CssClass { get; set; }
        public decimal BalanceMoney { get; set; }
        #endregion

        #region Constructors
        public Balance()
        {
            this.Deposit = 0;
            this.Expense = 0;
        }

        public Balance(decimal deposit, decimal expense)
        {
            this.Deposit = deposit;
            this.Expense = expense;
            CalculateBalance();
        }
        #endregion

        #region Methods
        private void CalculateBalance()
        {
            decimal balance = Deposit + Expense;
            string cssClass = string.Empty;
            if (balance > 0)
                cssClass = "alert alert-success";
            else if (balance < 0)
                cssClass = "alert alert-danger";
            else
                cssClass = "alert alert-dark";
            this.BalanceMoney = balance;
            this.CssClass = cssClass;

        }
        #endregion
    }
}
