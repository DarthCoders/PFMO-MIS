using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFMO.Entities
{
    public class Contact
    {
        public Guid ContactID { get; set; }

        [Display(Name = "Contact Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The Contact Name Value cannot exceed 17 characters. ")]
        public string ContactName { get; set; }


        [Display(Name = "Contact Address")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The Contact Name Value cannot exceed 100 characters. ")]
        public string ContactDescription { get; set; }


        [Display(Name = "Contact Type")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "The Contact Name Value cannot exceed 30 characters. ")]
        public string ContactType { get; set; }

        [Display(Name = "Contact Office")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "The Contact Name Value cannot exceed 50 characters. ")]
        public string ContactOffice { get; set; }

        [Display(Name = "Contact Email")]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }


        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }
    }
}
