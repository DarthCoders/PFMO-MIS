using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFMO.Entities
{
    public class SectionTask
    {
        public Guid SectionTaskID { get; set; }

        [Required]
        [Display(Name = "Section Task Title")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SectionTaskTitle { get; set; }

        [Display(Name = "Section Task Description")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SectionTaskDescription { get; set; }

        [Display(Name = "Section Assigned")]
        public Guid SectionID { get; set; }
        public virtual Section Section { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string SectionTaskStartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string SectionTaskEndDate { get; set; }
    }
}