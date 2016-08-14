using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFMO.Entities
{
    public class Personnel
    {
        public Guid PersonnelID { get; set; }

        public string PersonnelFullName
        {
            get { return PersonnelLastName + ", " + PersonnelFirstName; }
        }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string PersonnelLastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string PersonnelFirstName { get; set; }

        [Display(Name = "Gender")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "Value cannot exceed 10 characters. ")]
        public string PersonnelGender { get; set; }

        [Display(Name = "Designation")]
        public Guid PersonnelDesignationID { get; set; }
        public virtual PersonnelDesignation PersonnelDesignation { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string PersonnelRemarks { get; set; }


        [Display(Name = "Section Assigned")]
        public Guid SectionID { get; set; }
        public virtual Section Section { get; set; }


        [Display(Name = "Project Team Assigned")]
        public Guid ProjectTeamID { get; set; }
        public virtual ProjectTeam ProjectTeam { get; set; }

        public virtual ICollection<PersonnelTask> PersonnelTasks { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PersonnelHireDate { get; set; }

        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public long PersonnelContactNumber { get; set; }
    }
}