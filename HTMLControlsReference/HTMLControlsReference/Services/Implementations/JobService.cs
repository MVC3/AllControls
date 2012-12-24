using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;
using HTMLControlsReference.Services.Contracts;
using HTMLControlsReference.ViewModels;

namespace HTMLControlsReference.Services.Implementations
{
    public class JobService : IJobService
    {
        private IEmpDBContext _dataService;

        public JobService(IEmpDBContext jobDBContext)
        {
            _dataService = jobDBContext;
        }

        public List<JobTitle> getAllJobs()
        {
            return _dataService.JobTitles.ToList();
        }

        public JobTitle getJob(int id)
        {
            return _dataService.JobTitles.Where(j => j.JobID == id).SingleOrDefault();
        }
    }
}