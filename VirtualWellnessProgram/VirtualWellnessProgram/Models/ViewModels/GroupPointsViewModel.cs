using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models.ViewModels
{
    public class GroupPointsViewModel
    {
        [Display(Name= "Group Name")]
        public List<Group>Group { get; set; }
    }
}