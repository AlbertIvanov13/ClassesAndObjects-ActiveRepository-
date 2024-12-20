using System;
using System.Linq;

namespace _5._TeamWorkProjects
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int registeredTeamCount = int.Parse(Console.ReadLine());

			List<CreatingTeam> teams = new List<CreatingTeam>();

			List<CreatingTeam> teamsToDisband = new List<CreatingTeam>();

			for (int i = 0; i < registeredTeamCount; i++)
			{
				string[] teamCreation = { };

				teamCreation = Console.ReadLine().Split("-").ToArray();
				string user = teamCreation[0];
				string teamName = teamCreation[1];

				bool isCreated = teams.Select(x => x.TeamName).Contains(teamName);

				bool isUserExisting = teams.Any(x => x.User == user);
				bool isTeamExisting = teams.Any(x => x.TeamName == teamName);

				if (!isCreated)
				{
					if (isUserExisting)
					{
						Console.WriteLine($"{user} cannot create another team!");
					}
					else
					{
						teams.Add(new CreatingTeam { User = teamCreation[0], TeamName = teamCreation[1] });
						Console.WriteLine($"Team {teamName} has been created by {user}!");
					}
				}

				if (isCreated)
				{
					Console.WriteLine($"Team {teamName} was already created!");
				}
			}

			while (true)
			{
				string[] newArray = { };

				string? input = Console.ReadLine();

				if (input == "end of assignment")
				{
					break;
				}

				newArray = input.Split("->").ToArray();

				string newUser = newArray[0];
				string newTeamName = newArray[1];

				for (int i = 0; i < teams.Count; i++)
				{
					if (teams[i].TeamName == newTeamName && teams[i].User != newUser)
					{
						bool isTeamExisting = teams.Select(x => x.TeamName).Contains(newTeamName);
						bool isUserExisting = teams.Any(x => x.Members.Contains(newUser));
						if (!isTeamExisting)
						{
							Console.WriteLine($"Team {newTeamName} does not exist!");
							break;
						}
						else
						{
							foreach (var item in teams)
							{
								if (item.TeamName == newTeamName)
								{
									if (isUserExisting)
									{
										Console.WriteLine($"Member {newUser} cannot join team {newTeamName}!");
									}
									else
									{
										item.Members.Add(newUser);
									}
								}
							}
						}
					}
					else if (teams[i].TeamName == newTeamName && newUser == teams[i].User)
					{
						Console.WriteLine($"Member {newUser} cannot join team {teams[i].TeamName}!");
						break;
					}
					else
					{
						bool isTeamExisting = teams.Select(x => x.TeamName).Contains(newTeamName);
						if (!isTeamExisting)
						{
							Console.WriteLine($"Team {newTeamName} does not exist!");
							break;
						}
					}
				}
			}

			var orderedTeams = teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).Where(x => x.Members.Count > 0).ToList();
			foreach (var newTeam in orderedTeams)
			{
				Console.WriteLine(newTeam.TeamName);
				Console.WriteLine($"- {newTeam.User}");
				for (int i = 0; i < newTeam.Members.Count;)
				{
					var orderedUsers = newTeam.Members.OrderBy(x => x).ToList();
					foreach (var user in orderedUsers)
					{
						Console.WriteLine($"-- {user}");
					}
					break;
				}
			}

			Console.WriteLine("Teams to disband:");
			var orderedTeamsToDisband = teams.OrderBy(x => x.TeamName).Where(x => x.Members.Count < 1).ToList();
			foreach (var teamToDisband in orderedTeamsToDisband)
			{
				Console.WriteLine(teamToDisband.TeamName);
			}
		}
	}

	public class CreatingTeam
	{
		public string User { get; set; }
		public string TeamName { get; set; }
		public List<string> Members { get; set; }

		public CreatingTeam()
		{
			Members = new List<string>();
		}
		public override string ToString()
		{
			return $"Team {TeamName} has been created by {User}!";
		}
	}
}