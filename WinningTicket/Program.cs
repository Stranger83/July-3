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
			var allTickets = Regex.Split(Console.ReadLine(), @"\s*,\s*");

			var patternForValidTicket = @"\S{20}";
			for (int i = 0; i < allTickets.Length; i++)
			{
				var match = Regex.Match(allTickets[i], patternForValidTicket);
				if (match.Success)
				{
					var jackpot = Regex.Match(match.Value, @"(\$|\^|@|#)\1{19}");
					if (jackpot.Success)
					{
						Console.WriteLine($"ticket \"{match.Value}\" - 10{match.Value[0]} Jackpot!");
					} else if (!jackpot.Success)
					{
						var win = Regex.Match(match.Value, @"(\${6,}|\^{6,}|#{6,}|@{6,}).+(\1)");
						if (win.Success)
						{
							Console.WriteLine($"ticket \"{match.Value}\" - {win.Groups[1].Length}{win.Groups[1].Value[0]}");
						}
						else
						{
							Console.WriteLine($"ticket \"{match.Value}\" - no match");
						}
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