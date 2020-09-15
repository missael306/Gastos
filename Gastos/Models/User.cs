using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gastos.Models
{
    public class User
    {
       //------------------------
       //It represent to User in the system without details(lastName, Country, Address, etc.)    
       //Table: TblUsers
       //------------------------     
       [Key]         
       public int UserID { get; set; }
       [Required(ErrorMessage = "Proporcione un nombre.")]  
       public string Name { get; set; }
       [EmailAddressAttribute(ErrorMessage = "Proporcione un email valido.")]
       public string Email { get; set; }
       [Required(ErrorMessage = "Proporcione una contraseña.")]  
       [MaxLengthAttribute(15,ErrorMessage = "15 es el máximo de caracteres")]
       [MinLengthAttribute(1,ErrorMessage="5 es el mínimo de caracteres")]
       public string Password { get; set; }       
       
       //Relationships
       #region Relationships              
       public UserDetail UserDetail  { get; set; }
       public List<Transaction> Transactions {get; set;}
       #endregion
    }
}
