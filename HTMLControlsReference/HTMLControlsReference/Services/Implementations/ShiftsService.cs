using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;
using HTMLControlsReference.Services.Contracts;
using HTMLControlsReference.ViewModels;

namespace HTMLControlsReference.Services.Implementations
{
    public class ShiftsService: IShiftService
    {
        private IEmpDBContext _dataService;

        public ShiftsService(IEmpDBContext shiftDBContext)
        {
            _dataService = shiftDBContext;
        }

        public List<Shift> getAllShifts()
        {
            return _dataService.Shifts.ToList();
        }

        public Shift getShift(int id)
        {
            return _dataService.Shifts.Where(s => s.ShiftID == id).SingleOrDefault();
        }
    }
}