using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WA.CMS.AntiCorruption
{
    public class SystemParameterFacade
    {
	    private readonly SystemParamter sysParameter;

	    public SystemParameterFacade(SystemParamter sysParameter)
	    {
		    this.sysParameter = sysParameter;
	    }
	    public string GetCities()
	    {
		    return sysParameter.GetSetting("basic", "cities");
	    }

	    public string GetOrderStatus()
	    {
		    return sysParameter.GetSetting("basic", "order-status");
		}
    }
}
