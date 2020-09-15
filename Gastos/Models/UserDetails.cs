using System;
using System.ComponentModel.DataAnnotations;

namespace Gastos.Models
{
    public class UserDetail
    {
       //------------------------
       //It represent to User details.(lastname, address, country etc)
       //Table: TblUserDetails
       //------------------------              
       [Key]
       public int UserDetailID { get; set; }
       [Required(ErrorMessage = "Proporcione los apellidos.")]  
       public string Lastname { get; set; }       
       [Required(ErrorMessage = "Seleccione un género.")]  
       public string Gender { get; set; }       
       [RegularExpression(@"^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})$",ErrorMessage="Fecha no valida.")]
       public DateTime BirthDate { get; set; }       
       
       //Relationships
       #region Relationships       
       public int UserID { get; set; }
       public User User { get; set; }
       #endregion
    }
}
