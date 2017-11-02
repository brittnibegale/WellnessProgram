using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models.ViewModels
{
    public class CustomerEditGroupIdViewModel
    {
        public List<Customer>Customers { get; set; }

        public List<Group>Groups { get; set; }
    }
}