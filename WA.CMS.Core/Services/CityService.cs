using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA.CMS.AntiCorruption;
using WA.CMS.AntiCorruption.ValueObjects;
using WA.CMS.Core.Entities;

namespace WA.CMS.Core.Services
{
	public class CityService
	{
		private readonly ICitiesAdapter _citiesAdapter;

		public CityService(ICitiesAdapter citiesAdapter)
		{
			_citiesAdapter = citiesAdapter;
		}

		public IEnumerable<City> GetCities()
		{
			IEnumerable<CityVO> cities = _citiesAdapter.GetCities();

			foreach (var cityVo in cities)
			{
				yield return new City{Id = cityVo.Id, CityName = cityVo.CityName};
			}
		}
	}
}
