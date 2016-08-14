using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFMO.Entities
{
    public class ProjectTeam
    {
        public Guid ProjectTeamID { get; set; }

        [Required]
        [Display(Name = "Project Team")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string ProjectTeamName { get; set; }

        [Display(Name = "Project Team Description")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string ProjectTeamDescription { get; set; }

        public virtual ICollection<Personnel> Personnels { get; set; }

        [Display(Name = "Assigned Project")]
        public Guid ProjectID { get; set; }
        public virtual Project Project { get; set; }
    }
}
