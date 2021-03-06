﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models
{
    public class Audit
    {
        public Guid AuditId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Area Accessed")]
        public string AreaAccessed { get; set; }

        [Display(Name = "Date Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string Timestamp { get; set; }

        public Audit()
        {
            
        }
    }

    public class AuditingContext : DbContext
    {
        public DbSet<Audit>AuditRecords { get; set; }
    }

    public class PostingModel
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }

        public PostingModel()
        {
            
        }
    }
}