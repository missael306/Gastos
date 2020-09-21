using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gastos.Models
{
    public class TypeTransaction
    {
       //------------------------
       //It represent to type transaction (expense, outlay).    
       //Table: TblTypeTransaction
       //------------------------ 
       #region Attributes
       [Key]       
       public int TypeTransactionID { get; set; }
       [Required(ErrorMessage = "Proporcione un nombre.")]
       [Display(Name ="Nombre")]
       public string Name { get; set; }       
       #endregion

       #region Constructor
       #endregion

       #region Methods
       #endregion      

       #region Relationships
       public List<Transaction> Transactions { get; set; }
       public List<Category> Categories { get; set; }
       #endregion
    }
}
