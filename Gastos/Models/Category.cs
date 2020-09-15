using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gastos.Models
{
    public class Category
    {
        //------------------------
        //It represent to Categories in the system,(home, car, gifts, etc)    
        //Table: CatCategory
        //------------------------  
        #region Attributes
        [Key]
        public int CategoryID { get; set; }
        [Display(Name ="Nombre")]   
        [Required(ErrorMessage = "Proporcione un nombre.")]
        [MaxLengthAttribute(25,ErrorMessage = "15 es el máximo de caracteres")]
        [MinLengthAttribute(1,ErrorMessage="Nombre no puede ser vacío")]
        public string Name { get; set; }    
        [Display(Name ="Fecha de registro")]
        [Required(ErrorMessage = "Fecha de registo es requerida.")]   
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegisterDate { get; set; }
        [Display(Name ="Activo")]
        [Required(ErrorMessage = "Activo es requerido.")]
        public bool Active { get; set; }
        #endregion

        #region Constructor
        #endregion
    
        #region Relationships
        [Display(Name ="Icono")]
        [Required(ErrorMessage = "Seleccione un icono.")]        
        public int IconID { get; set; }
        public virtual Icon Icon { get; set; }

        [Display(Name ="Clasificación")]
        [Required(ErrorMessage = "Clasificación es requerido.")]
        public int TypeTransactionID { get; set; }
        public TypeTransaction TypeTransaction { get; set; }            
        #endregion

        #region Methods
        #endregion
    }
}
