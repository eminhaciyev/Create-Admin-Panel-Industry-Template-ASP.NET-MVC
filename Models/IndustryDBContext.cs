using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminPanelAndIndustry.Models
{
    public class IndustryDBContext:DbContext
    {
        public IndustryDBContext() : base("Industry") { }      

        public DbSet<Contact> Contacts { get; set; }
    }
}