using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WA.CMS;
using WA.CMS.AntiCorruption;
using WA.CMS.Core.Entities;
using WA.CMS.Core.Services;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<SystemParameterRepository>().As<ISystemParameterRepo>();

			builder.RegisterType<SystemParamter>().AsSelf();

			builder.RegisterType<CitiesAdapter4String>().As<ICitiesAdapter>();
			builder.RegisterType<OrderStatusAdapter4Json>().As<IOrderStatusAdapter>();

			builder.RegisterType<SystemParameterFacade>().AsSelf();

			builder.RegisterType<CityService>().AsSelf();
			builder.RegisterType<OrderService>().AsSelf();

			var container = builder.Build();

			IEnumerable<City> cities;
			IEnumerable<OrderStatus> orderStatuses;

			using (var scope = container.BeginLifetimeScope())
			{
				var cityService = scope.Resolve<CityService>();
				cities = cityService.GetCities();

				var orderService = scope.Resolve<OrderService>();
				orderStatuses = orderService.GetOrderStatus();
			}

			foreach (var city in cities)
			{
				Console.WriteLine($"id={city.Id}, name={city.CityName}");
			}

			Console.WriteLine("==============");
			foreach (var orderStatuse in orderStatuses)
			{
				Console.WriteLine($"id={orderStatuse.Id}, description={orderStatuse.Description}");
			}
		}
	}
}
