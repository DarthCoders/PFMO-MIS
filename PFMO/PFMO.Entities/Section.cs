using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PFMO.Entities
{
    public class Section
    {
        public Guid SectionID { get; set; }

        [Required]
        [Display(Name = "Section Name")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SectionName { get; set; }

        public virtual ICollection<SectionHead> SectionHeads { get; set; }

        [Display(Name = "Section Type")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SectionType { get; set; }

        [Display(Name = "Section Description")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string SectionDescription { get; set; }

        public virtual ICollection<Personnel> Personnels { get; set; }

        public virtual ICollection<SectionTask> SectionTasks { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SectionDateCreated { get; set; }
    }
}