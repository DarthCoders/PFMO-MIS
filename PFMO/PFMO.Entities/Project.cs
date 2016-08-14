using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PFMO.Entities
{
    public class Project
    {
        public Guid ProjectID { get; set; }

        [Required]
        [Display(Name = "Project Title")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string ProjectName { get; set; }

        [Display(Name = "Project Status")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string ProjectStatus { get; set; }

        [Display(Name = "Project Completion")]
        [Range(0, 100)]
        public int ProjectCompletion { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectStartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProjectEndDate { get; set; }


        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}