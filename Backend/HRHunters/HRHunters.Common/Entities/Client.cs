﻿using HRHunters.Common.Enums;
using HRHunters.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRHunters.Common.Entities
{
    public class Client : Entity
    {
        public ClientStatus Status { get; set; }
        [Required]
        public string Location { get; set; }
        public int UserId { get; set; }
        public new int Id { get { return UserId; } set { Id = value; } }

        public User User { get; set; }
        public ICollection<JobPosting> JobPostings { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}