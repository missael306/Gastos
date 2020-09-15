using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gastos.Models
{
    [Table("Icons", Schema="Cat")]
    public class Icon
    {
        //------------------------
        //It represent the Icons in  the categories
        //Table: CatICon
        //------------------------  
        #region Attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IconID { get; set; }
        [MaxLength(50)]
        public string IconName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegisterDate { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool Active { get; set; }
        #endregion

        #region Constructor
        public Icon()
        {
            this.Active = true;
            this.IconID = 0;
            this.IconName = string.Empty;
            this.RegisterDate = DateTime.Now;
        }

        public Icon( string _icon, int _id)
        {
            this.IconID = _id;
            this.Active = true;            
            this.IconName = _icon;
            this.RegisterDate = DateTime.Now;
        }
        #endregion
    }
}
