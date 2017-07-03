using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftUniKaraoke
{
	class Program
	{
		static void Main(string[] args)
		{
			var ppl = Regex.Split(Console.ReadLine(), @"\s*,\s*")
				.ToArray();
			var songs = Regex.Split(Console.ReadLine(), @"\s*,\s*")
				.ToArray();
			var input = Console.ReadLine();
			var peopleAwards = new Dictionary<string, List<string>>();

			while (input != "dawn")
			{
				var tokens = Regex.Split(input, @"\s*,\s*")
				.ToArray();
				var participant = tokens[0];
				var song = tokens[1];
				var award = tokens[2];

				if (ppl.Contains(participant) && songs.Contains(song))
				{
					if (!peopleAwards.ContainsKey(participant))
					{
						peopleAwards[participant] = new List<string>();
					}
					peopleAwards[participant].Add(award);
				}
				input = Console.ReadLine();
			}

			if (peopleAwards.Values.Count == 0)
			{
				Console.WriteLine("No awards");
				return;
			}

			var resultDict = peopleAwards.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
				.ToDictionary(x => x.Key, x => x.Value);

			foreach (var kvp in resultDict)
			{
				var participant = kvp.Key;
				var awards = kvp.Value.Distinct().ToList();
				Console.WriteLine($"{participant}: {awards.Count} awards");
				foreach (var aw in awards.OrderBy(x => x))
				{
					Console.WriteLine($"--{aw}");
				}
			}
		}
	}
}
