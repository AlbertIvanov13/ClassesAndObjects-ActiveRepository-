using System;
using System.Linq;

namespace _5._TeamWorkProjects
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int registeredTeamCount = int.Parse(Console.ReadLine());

			CreatingTeam team = new CreatingTeam();

			List<CreatingTeam> teams = new List<CreatingTeam>();
			List<CreatingTeam> joining = new List<CreatingTeam>();

			List<JoiningUser> names = new List<JoiningUser>();

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
					teams.Add(new CreatingTeam { User = teamCreation[0], TeamName = teamCreation[1] });
					names.Add(new JoiningUser { User = teamCreation[0], TeamName = teamCreation[1] });
					team.Members.Add(teamCreation[0]);

					Console.WriteLine($"Team {teamName} has been created by {user}!");
				}

				if (isCreated)
				{
					Console.WriteLine($"Team {teamName} was already created!");
				}
			}

			List<CreatingTeam> teamsToDisband = new List<CreatingTeam>();
			List<CreatingTeam> users = new List<CreatingTeam>();

			bool isDisband = true;

			int counter = 0;

			while (true)
			{
				string[] newArray = { };

				string input = Console.ReadLine();

				if (input == "end of assignment")
				{
					break;
				}

				newArray = input.Split("->").ToArray();

				string newUser = newArray[0];
				string newTeamName = newArray[1];

				for (int i = 0; i < teams.Count; i++)
				{
					if (teams[i].TeamName == newTeamName && newUser != teams[i].User)
					{
						bool isTeamExisting = teams.Select(x => x.TeamName).Contains(newTeamName);
						if (!isTeamExisting)
						{
							Console.WriteLine($"Team {newTeamName} does not exist!");
							break;
						}
						else
						{
							joining.Add(new CreatingTeam { User = newArray[0], TeamName = newArray[1] });
							users.Add(teams[i]);
							break;
						}
					}
					else if (teams[i].TeamName == newTeamName && newUser == teams[i].User)
					{
						Console.WriteLine($"Member {newUser} cannot join team {teams[i].TeamName}!");
						teamsToDisband.Add(teams[i]);
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

			//var groupedTeams = joining.GroupBy(x => x.TeamName).ToList();

			//foreach (var groupedTeam in groupedTeams)
			//{
			//             Console.WriteLine($"{groupedTeam.Key}");
			//	foreach (var newTeam in names)
			//	{
			//		if (groupedTeam.Key == newTeam.TeamName)
			//		{
			//			Console.WriteLine($"- { newTeam.User}");
			//			foreach (var newUser in joining)
			//			{
			//				if (newUser.TeamName == newTeam.TeamName)
			//				{
			//					Console.WriteLine($"-- {newUser.User}");
			//				}
			//			}
			//		}
			//	}
			//}

			//foreach (var newTeam in names)
			//{
			//	foreach (var item in joining)
			//	{
			//		if (newTeam.TeamName == item.TeamName)
			//		{
			//			var sortedByName = names.OrderByDescending(t => t.User).ToList();
			//			foreach (var teamName in sortedByName)
			//			{
			//				foreach (var newName in joining)
			//				{
			//					if (newName.TeamName == teamName.TeamName)
			//					{
			//						Console.WriteLine(teamName.TeamName);
			//						foreach (var creator in names)
			//						{
			//							if (creator.User == teamName.User)
			//							{
			//								foreach (var name in names)
			//								{
			//									if (creator.TeamName == name.TeamName)
			//									{
			//										Console.WriteLine($"- {name.User}");
			//										break;
			//									}
			//								}
			//								var orderedUserNames = joining.OrderBy(x => joining[0]).ToList();
			//								foreach (var user in orderedUserNames)
			//								{
			//									foreach (var newUser in orderedUserNames)
			//									{
			//										if (creator.TeamName == newUser.TeamName)
			//										{
			//											Console.WriteLine($"-- {newUser.User}");
			//										}
			//									}
			//									break;
			//								}
			//								break;
			//							}
			//							continue;
			//						}
			//						break;
			//					}
			//					else
			//					{
			//						continue;
			//					}
			//				}
			//			}
			//			break;
			//		}
			//		break;
			//	}
			//}

			Console.WriteLine("Teams to disband:");
			var orderedTeamsToDisband = teamsToDisband.OrderBy(x => x.TeamName).ToList();
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

	public class JoiningUser
	{
		public string User { get; set; }
		public string TeamName { get; set; }
	}
}