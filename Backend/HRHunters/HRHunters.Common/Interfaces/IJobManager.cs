﻿using HRHunters.Common.Entities;
using HRHunters.Common.Enums;
using HRHunters.Common.Requests.Admin;
using HRHunters.Common.Requests.Users;
using HRHunters.Common.Responses.AdminDashboard;
using HRHunters.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRHunters.Common.Interfaces
{
    public interface IJobManager : IBaseManager
    {
        IEnumerable<JobInfo> GetMultiple(int pageSize, int currentPage, string sortedBy, SortDirection sortDir, string filterBy, string filterQuery);
        IEnumerable<JobPosting> CreateJobPosting(JobSubmit jobSubmit);
        JobPosting GetOneJobPosting(int id);
        JobInfo UpdateJob(int id, string status, JobUpdate jobSubmit);

    }
}
