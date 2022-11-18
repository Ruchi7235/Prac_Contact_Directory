using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prac_Contact_Directory.Models
{
    public class ContactGroup
    {
        
        public int ContactGroupID { get; set; }
        [Display(Name ="Contact Group Name"),Required,StringLength(40)]
        public string ContactGroupName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Role { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Group Group { get; set; }
    }
}