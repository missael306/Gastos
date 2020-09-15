using System;
using System.ComponentModel.DataAnnotations;

namespace Gastos.Models
{
    public class Transaction
    {
       //------------------------
       //It represent to transaction deposit,outlay, when?, how much? etc
       //Table: TblTransactions
       //------------------------     
        #region Attributes
        [Key]
        public int TransactionID { get; set; }
        [Display(Name ="Monto")]                     
        [Required(ErrorMessage = "Ingrese un monto.")]       
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "Ingrese una fecha.")]
        [Display(Name ="Fecha")]
        public DateTime ActionDate { get; set; }       
        [Display(Name ="Comentario")]
        [MaxLength(25, ErrorMessage = "Por favor, no escribas más de {0} caracteres.")]
        public string Comment { get; set; }
        #endregion  

        #region Constructors
        public Transaction()
        {  
            this.TransactionID = 0; 
            this.Comment = string.Empty;
            this.ActionDate = DateTime.Now;
            this.CategoryID = 0;
            this.Value = 0.0m;
        }
        #endregion  

        #region Relationships
        public int UserID { get; set; }
        public User User { get; set; }
        [Display(Name ="Tipo de transacción")]
        [Required(ErrorMessage = "Tipo de transacción es requerido.")]
        public int TypeTransactionID { get; set; }
        public TypeTransaction TypeTransaction { get; set; }
        [Display(Name ="Categoria")]
        [Required(ErrorMessage = "Categoria es requerido.")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        #endregion

        #region Methods
        #endregion 
    }
}
