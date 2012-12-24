using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTMLControlsReference.Models;
using HTMLControlsReference.Services.Contracts;

namespace HTMLControlsReference.Services.Implementations
{
    public class StateService : IStateService
    {
        private IEmpDBContext _dataservice;

        public StateService(IEmpDBContext StateDBContext)
        {
            _dataservice = StateDBContext;
        }

        public List<State> GetAllStates()
        {
           return _dataservice.States.ToList();
        }

        public State GetState(int id)
        {
            return _dataservice.States.Where(s => s.StateID == id).SingleOrDefault();
        }
    }
}