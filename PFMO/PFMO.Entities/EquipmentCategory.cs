using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PFMO.Entities
{
    public class EquipmentCategory
    {
        public Guid EquipmentCategoryID { get; set; }

        [Required]
        [Display(Name = "Category Title")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string EquipmentCategoryName { get; set; }

        [Display(Name = "Category Description")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string EquipmentCategoryDescription { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}
