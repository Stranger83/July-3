using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoTheWalker
{
	class Program
	{
		static void Main(string[] args)
		{
			var startTime = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
			var startSeconds = startTime[2];
			var startMinutes = startTime[1];
			var startHours = startTime[0];
			var steps = long.Parse(Console.ReadLine());
			var secondsPerStep = long.Parse(Console.ReadLine());

			long travelTimeInSecs = steps * secondsPerStep;

			var finalSeconds = (startSeconds + travelTimeInSecs) % 60;
			var finalMinutes = (startMinutes + ((startSeconds + travelTimeInSecs) / 60)) % 60;
			var finalHours = (startHours + (startMinutes + ((startSeconds + travelTimeInSecs) / 60)) / 60) % 24;
			
			Console.WriteLine($"Time Arrival: {finalHours:d2}:{finalMinutes:d2}:{finalSeconds:d2}");
		}
	}
}
