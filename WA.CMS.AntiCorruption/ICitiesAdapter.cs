using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WA.CMS.AntiCorruption.ValueObjects;

namespace WA.CMS.AntiCorruption
{
	public interface ICitiesAdapter
	{
		IEnumerable<CityVO> GetCities();
	}
}
