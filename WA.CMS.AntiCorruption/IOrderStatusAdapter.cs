using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WA.CMS.AntiCorruption.ValueObjects;

namespace WA.CMS.AntiCorruption
{
	public interface IOrderStatusAdapter
	{
		IEnumerable<OrderStatusVO> GetOrderStatuses();
	}

	public class OrderStatusAdapter4Json : IOrderStatusAdapter
	{
		private readonly SystemParameterFacade _facade;

		public OrderStatusAdapter4Json(SystemParameterFacade facade)
		{
			_facade = facade;
		}
		public IEnumerable<OrderStatusVO> GetOrderStatuses()
		{
			string setting = _facade.GetOrderStatus();
			JArray json = JArray.Parse(setting);

			foreach (var token in json)
			{
				int id = token.Value<int>("id");
				string value = token.Value<string>("text");

				yield return new OrderStatusVO{Id=id, StatusName = value};
			}
		}
	}

}
