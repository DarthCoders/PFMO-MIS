using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PFMO.Entities
{
    public class SupplyCategory
    {
        public Guid SupplyCategoryID { get; set; }

        [Required]
        [Display(Name = "Category Title")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SupplyCategoryName { get; set; }

        [Display(Name = "Category Description")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SupplyCategoryDescription { get; set; }

        public virtual ICollection<Supply> Supply { get; set; }
    }
}