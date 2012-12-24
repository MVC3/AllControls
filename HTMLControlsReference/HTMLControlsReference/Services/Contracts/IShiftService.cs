using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;
using HTMLControlsReference.ViewModels;

namespace HTMLControlsReference.Services.Contracts
{
    public interface IShiftService
    {
        List<Shift> getAllShifts();
        Shift getShift(int id);
    }
}