using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTMLControlsReference.Models;

namespace HTMLControlsReference.Services.Contracts
{
    public interface ICityService
    {
        List<City> GetAllCities(int stateID);
        City GetCity(int id);
    }
}