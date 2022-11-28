using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prac_Contact_Directory.Models
{
    public class Contact
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required, Display(Name = "Employee Name"), StringLength(30)]
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        [EmailAddress, Required, StringLength(80)]
        public string Email { get; set; }

        [Required, Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<ContactGroup> ContactGroups { get; set; }
        public virtual ICollection<DistributionList> DistributionLists { get; set; }

        // SelectList for dropdown of multiple list
     
    }
}