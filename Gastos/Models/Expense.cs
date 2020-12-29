using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Models
{
    public class Expense
    {
        //------------------------
        //It represent expenses dor day in the full calendar 
        //------------------------              
        #region Attributes
        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string backgroundColor { get; set; }
        public string textColor { get; set; }
        public string eventBorderColor { get; set; }

        public decimal expense { get; set; }
        public decimal deposit { get; set; }
        #endregion

        #region Constructors    
        public Expense()
        {
            this.textColor = "white";
            this.eventBorderColor = "none";
        }
        #endregion
    }
}
