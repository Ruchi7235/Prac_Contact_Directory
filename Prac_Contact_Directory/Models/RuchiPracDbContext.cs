using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Prac_Contact_Directory.Models
{
    public class RuchiPracDbContext : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactGroup> ContactGroup { get; set; }
        public DbSet<DistributionList> DistributionList { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
   
}