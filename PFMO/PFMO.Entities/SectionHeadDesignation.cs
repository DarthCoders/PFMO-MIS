using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMO.Entities
{
    public class SectionHeadDesignation
    {
        public Guid SectionHeadDesignationID { get; set; }

        [Required]
        [Display(Name = "Designation")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SectionHeadDesignationName { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [StringLength(500, ErrorMessage = "Value cannot exceed 500 characters. ")]
        public string SectionHeadDesignationDescription { get; set; }

        public virtual ICollection<SectionHead> SectionHead { get; set; }
    }
}
