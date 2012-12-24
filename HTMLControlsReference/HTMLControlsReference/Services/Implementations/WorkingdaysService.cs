using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;
using HTMLControlsReference.Services.Contracts;
using HTMLControlsReference.ViewModels;

namespace HTMLControlsReference.Services.Implementations
{
    public class WorkingdaysService : IWorkingDayService
    {
        private IEmpDBContext _dataService;

        public WorkingdaysService(IEmpDBContext workingdayDBContext)
        {
            _dataService = workingdayDBContext;
        }
        public List<WorkingDay> getAllWorkingDays()
        {
            return _dataService.WorkingDays.ToList();
        }

        public WorkingDay getSelectedWorkingday(int id)
        {
            return _dataService.WorkingDays.Where(w => w.WorkingDayID == id).SingleOrDefault();
        }
    }
}