using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gastos.Models
{
    public class Alert
    {
        //------------------------
        //It represent the alerts for the user    
        //------------------------              
        #region Attributes
        public string Type { get; set; }
        public string Message { get; set; }
        #endregion

        #region Constructors
        public Alert()
        {
            this.Type = "";
            this.Message = "";
        }

        public Alert(string _type, string _message)
        {
            this.Type = _type;
            this.Message = _message;
        }
        #endregion
    }
}
