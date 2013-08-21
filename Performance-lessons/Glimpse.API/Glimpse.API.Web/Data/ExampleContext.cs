using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Glimpse.API.Web.Models;

namespace Glimpse.API.Web.Data
{
    public class ExampleContext :DbContext
    {
        public ExampleContext() : base("DefaultConnection")
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Gadget> Gadgets { get; set; }
    }
}