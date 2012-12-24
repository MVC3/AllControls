using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTMLControlsReference.Models;


namespace HTMLControlsReference.Services.Contracts
{
    public interface IStateService
    {
        List<State> GetAllStates();
        State GetState(int id);
    }
}