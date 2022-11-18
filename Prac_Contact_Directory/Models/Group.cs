using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Prac_Contact_Directory.Models
{
    public class Group
    {

        [Key]
        [Column(Order = 1),Display(Name ="Employee Id")]
        public int EmployeeId { get; set; }

        [Key]
        [Column(Order = 2),Display(Name ="Contact Group Id")]
        public int ContactGroupId { get; set; }

        [Display (Name="Department Code")]
        public int DepartmentCode { get; set; }

        [Display(Name ="Group Name"),Required,StringLength(50)]
        public string GroupName { get; set; }

        public virtual ICollection<ContactGroup> ContactGroups { get; set; }
        public virtual ICollection<DistributionList> DistributionLists { get; set; }
    }
}