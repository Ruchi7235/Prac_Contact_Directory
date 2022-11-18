using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prac_Contact_Directory.Models
{
    public class DistributionList
    {
        public int DistributionListId { get; set; }

        [Required,Display(Name ="Distribution List Name"),StringLength(40)]
        public string DistributionListName { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}