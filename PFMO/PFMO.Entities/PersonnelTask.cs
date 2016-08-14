using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFMO.Entities
{
    public class PersonnelTask
    {
        public Guid PersonnelTaskID { get; set; }

        [Required]
        [Display(Name = "Personnel Task Title")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string PersonnelTaskTitle { get; set; }

        [Display(Name = "Personnel Task Description")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string PersonnelTaskDescription { get; set; }

        [Display(Name = "Personnel Assigned")]
        public Guid PersonnelID { get; set; }
        public virtual Personnel Personnel { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string PersonnelTaskStartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string PersonnelTaskEndDate { get; set; }
    }
}