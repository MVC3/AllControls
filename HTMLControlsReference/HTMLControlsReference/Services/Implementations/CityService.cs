using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTMLControlsReference.Models;
using HTMLControlsReference.Services.Contracts;
using HTMLControlsReference.ViewModels;

namespace HTMLControlsReference.Services.Implementations
{
    public class CityService : ICityService
    {
        private IEmpDBContext _dataService;

    public CityService (IEmpDBContext CityDBContext)
	{
        _dataService = CityDBContext;
	}

        public List<City> GetAllCities(int stateID)
        {
            return _dataService.Cities.Where(c => c.CityID == stateID).ToList();
        }

        public City GetCity(int id)
        {
            return _dataService.Cities.Where(c => c.CityID == id).SingleOrDefault();
        }
    }
}