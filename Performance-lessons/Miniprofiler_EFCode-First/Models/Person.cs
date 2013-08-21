using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miniprofiler.CodeFirst.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public List<Gadget> Gadgets { get; set; }
    }
}