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
	public class OrderService
	{
		private readonly IOrderStatusAdapter _adapter;

		public OrderService(IOrderStatusAdapter adapter)
		{
			_adapter = adapter;
		}

		public IEnumerable<OrderStatus> GetOrderStatus()
		{
			IEnumerable<OrderStatusVO> items = _adapter.GetOrderStatuses();

			foreach (var item in items)
			{
				yield return new OrderStatus{ Id = item.Id,Description = item.StatusName };
			}
		}
	}
}
