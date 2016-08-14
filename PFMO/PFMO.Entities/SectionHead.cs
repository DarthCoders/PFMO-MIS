using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFMO.Entities
{
    public class SectionHead
    {
        public Guid SectionHeadID { get; set; }

        public string SectionHeadFullName
        {
            get { return SectionHeadLastName + ", " + SectionHeadFirstName; }
        }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SectionHeadLastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SectionHeadFirstName { get; set; }

        [Display(Name = "Gender")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "Value cannot exceed 10 characters. ")]
        public string SectionHeadGender { get; set; }

        [Display(Name = "Designation")]
        public Guid SectionHeadDesignationID { get; set; }
        public virtual SectionHeadDesignation SectionHeadDesignation { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SectionHeadRemarks { get; set; }

        [Display(Name = "Section Assigned")]
        public Guid SectionID { get; set; }
        public virtual Section Section { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SectionHeadHireDate { get; set; }

        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public long SectionHeadContactNumber { get; set; }
    }
}
