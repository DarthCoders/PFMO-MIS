using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFMO.Entities
{
    public class Supply
    {
        public Guid SupplyID { get; set; }  

        [Required]
        [Display(Name = "Supply Code")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 50 characters. ")]
        public string SupplyCode { get; set; }

        [Required]
        [Display(Name = "Supply Name")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SupplyName { get; set; }


        [Display(Name = "Category")]
        public Guid SupplyCategoryID { get; set; }
        public virtual SupplyCategory SupplyCategory { get; set; }


        [Display(Name = "Remarks")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SupplyRemarks { get; set; }


        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SupplyStatus { get; set; }

        [Display(Name = "Balance")]
        public int SupplyBalance { get; set; }

        [Display(Name = "Unit of Measure")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SupplyUnit { get; set; }

        [Display(Name = "Reorder Point")]
        public int SupplyReorderPoint { get; set; }

        [Display(Name = "Target")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string Target { get; set; }

        [Display(Name = "Project")]
        public Guid ProjectID { get; set; }
        public virtual Project Project { get; set; }


        [Display(Name = "Expiry Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SupplyExpiryDate { get; set; }
    }
}
