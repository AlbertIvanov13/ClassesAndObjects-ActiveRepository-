using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace _5._TeamWorkProjects
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int teamsCount = int.Parse(Console.ReadLine());

			List<Team> teams = new List<Team>();
			List<string> creators = new List<string>();
			List<string> members = new List<string>();

			for (int i = 0; i < teamsCount; i++)
			{
				string[] input = Console.ReadLine().Split("-").ToArray();

				string name = input[0];
				string team = input[1];
				creators.Add(name);

				bool isTeamExisting = teams.Select(x => x.TeamName).Contains(team);

				bool isCreatorExisting = teams.Any(x => x.Name == name);

				if (!isTeamExisting && !isCreatorExisting)
				{
					Team newTeam = (new Team { Name = name, TeamName = team});

					teams.Add(newTeam);

                    Console.WriteLine($"Team {team} has been created by {name}!");
				}
				else if (isTeamExisting)
				{
                    Console.WriteLine($"Team {team} was already created!");
				}
				else if (isCreatorExisting)
				{
                    Console.WriteLine($"{name} cannot create another team!");
				}
			}

			while (true)
			{
				string input = Console.ReadLine();

				if (input == "end of assignment")
				{
					break;
				}

				string[] newInput = input.Split("->").ToArray();

				string userToJoin = newInput[0];
				string teamToJoin = newInput[1];

				bool isTeamExisting = teams.Any(x => x.TeamName == teamToJoin);

				bool isCreatorExisting = teams.Any(x => x.Name == userToJoin);

				if (isTeamExisting && !isCreatorExisting)
				{

				}
			}
		}

		public class Team
		{
			public string Name { get; set; }
			public string TeamName { get; set; }
			//public List<string> Members { get; set; }
		}
	}
}