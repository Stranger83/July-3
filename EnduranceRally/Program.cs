using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduranceRally
{
	class Driver
	{
		public string Name { get; set; }
		public double Fuel { get; set; }
		public int LastIndexReached { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			var drivers = Console.ReadLine().Split().ToArray();
			var zones = Console.ReadLine().Split().Select(double.Parse).ToArray();
			var checkpoints = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var allDrivers = new List<Driver>();
			for (int i = 0; i < drivers.Length; i++)
			{
				var fuel = drivers[i].ToCharArray().Take(1).Select(x => (int)x).ToArray();
				Driver driver = new Driver()
				{
					Name = drivers[i],
					Fuel = fuel[0]
				};
				for (int j = 0; j < zones.Length; j++)
				{
					if (checkpoints.Contains(j))
					{
						driver.Fuel += zones[j];
					}
					else
					{
						driver.Fuel -= zones[j];
					}
					if (driver.Fuel <= 0)
					{
						driver.LastIndexReached = j;
						break;
					}
				}
				allDrivers.Add(driver);
			}
			foreach (var driver in allDrivers)
			{
				if (driver.Fuel > 0)
				{
					Console.WriteLine($"{driver.Name} - fuel left {driver.Fuel:f2}");
				}
				else
				{
					Console.WriteLine($"{driver.Name} - reached {driver.LastIndexReached}"); 
				}
			}
		}
	}
}
