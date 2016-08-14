using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMO.Entities
{
    public class PersonnelDesignation
    {
        public Guid PersonnelDesignationID { get; set; }

        [Required]
        [Display(Name = "Designation")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "Value cannot exceed 200 characters. ")]
        public string PersonnelDesignationName { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        [StringLength(500, ErrorMessage = "Value cannot exceed 500 characters. ")]
        public string PersonnelDesignationDescription { get; set; }

        public virtual ICollection<Personnel> Personnel { get; set; }

    }
}
