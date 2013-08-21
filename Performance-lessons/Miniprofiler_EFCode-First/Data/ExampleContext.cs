using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Miniprofiler.CodeFirst.Models;

namespace Miniprofiler.CodeFirst.Data
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