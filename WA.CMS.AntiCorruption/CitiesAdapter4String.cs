using System;
using System.Collections.Generic;
using System.Linq;
using WA.CMS.AntiCorruption.ValueObjects;

namespace WA.CMS.AntiCorruption
{
	/// <summary>
	/// 可以將字串轉成 CityVO collection
	/// </summary>
	public class CitiesAdapter4String : ICitiesAdapter
	{
		private readonly SystemParameterFacade _facade;

		public CitiesAdapter4String(SystemParameterFacade facade)
		{
			_facade = facade;
		}

		public IEnumerable<CityVO> GetCities()
		{
			string cities = _facade.GetCities();
			return cities.Split(';') // {"1=A", "2=B"}
				.Select(item => parseCity(item));
		}

		private CityVO parseCity(string item)
		{
			string[] setting = item.Split('=');
			return new CityVO {Id = Convert.ToInt32(setting[0]), CityName = setting[1]};
		}
	}
}