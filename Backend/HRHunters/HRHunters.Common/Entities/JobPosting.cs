﻿using HRHunters.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRHunters.Common.Entities
{
    public class JobPosting : Entity<int>
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphabet letters are allowed.")]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Date")]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public string Location { get; set; }
        [StringLength(800)]
        public string Description { get; set; }
        [Required]
        public string EmpCategory { get; set; }
        [Required]
        public string Education { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        [Required]
        public string NeededExperience { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}