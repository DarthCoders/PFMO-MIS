using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PFMO.Entities
{
    public class Equipment
    {
        public Guid EquipmentID { get; set; }

        [Required]
        [Display(Name = "Equipment Code")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 50 characters. ")]
        public string EquipmentCode { get; set; }

        [Required]
        [Display(Name = "Equipment Name")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string EquipmentName { get; set; }


        [Display(Name = "Category")]
        public Guid EquipmentCategoryID { get; set; }
        public virtual EquipmentCategory EquipmentCategory { get; set; }


        [Display(Name = "Remarks")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string EquipmentRemarks { get; set; }


        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string EquipmentStatus { get; set; }


        [Display(Name = "Balance")]
        public int EquipmentBalance { get; set; }


        [Display(Name = "Unit of Measure")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string EquipmentUnit { get; set; }

        [Display(Name = "Reorder Point")]
        public int EquipmentReorderPoint { get; set; }

        [Display(Name = "Target")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string Target { get; set; }

        [Display(Name = "Expiry Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EquipmentExpiryDate { get; set; }

    }
}
