using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;

namespace HTMLControlsReference.Services.Contracts
{
    public interface IJobService
    {
        List<JobTitle> getAllJobs();
        JobTitle getJob(int id);
    }
}