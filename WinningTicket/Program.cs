using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinningTicket
{
	class Program
	{
		static void Main(string[] args)
		{
			var allTickets = Console.ReadLine()
				.Split(',')
				.Select(a => a.Trim())
				.ToArray();

			for (int i = 0; i < allTickets.Length; i++)
			{
				var ticket = allTickets[i].Trim();

				if (ticket.Length == 20)
				{
					var leftSide = ticket.Substring(0, 10);
					var rightSide = ticket.Substring(10);
					var winPattern = @"(#{6,10}|@{6,10}|\${6,10}|\^{6,10})";

					var winLeft = Regex.Match(leftSide, winPattern);
					var winRight = Regex.Match(rightSide, winPattern);
					if (winLeft.Success && winRight.Success
						&& winLeft.Value[0] == winRight.Value[0])
					{
						var count = Math.Min(winLeft.Length, winRight.Length);
						if (count == 10)
						{
							Console.WriteLine($"ticket \"{ticket}\" - 10{winLeft.Value[0]} Jackpot!");
						}
						else
						{
							Console.WriteLine($"ticket \"{ticket}\" - {count}{winLeft.Value[0]}");
						}
					}
					else
					{
						Console.WriteLine($"ticket \"{ticket}\" - no match");
					}
				}
				else
				{
					Console.WriteLine($"invalid ticket");
				}
			}
		}
	}
}