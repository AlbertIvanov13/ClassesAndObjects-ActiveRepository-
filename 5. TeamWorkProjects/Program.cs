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
			JoiningUser join = new JoiningUser();

			List<CreatingTeam> teams = new List<CreatingTeam>();
			List<JoiningUser> joining = new List<JoiningUser>();

			List<JoiningUser> names = new List<JoiningUser>();

			for (int i = 0; i < registeredTeamCount; i++)
			{
				string[] teamCreation = { };

				teamCreation = Console.ReadLine().Split("-").ToArray();
				string user = teamCreation[0];
				string teamName = teamCreation[1];

				bool isCreated = teams.Select(x => x.TeamName).Contains(teamName);

				bool isUserExisting = teams.Any(x => x.User == user);

				if (!isCreated)
				{
					teams.Add(new CreatingTeam { User = teamCreation[0], TeamName = teamCreation[1] });
					names.Add(new JoiningUser { User = teamCreation[0], TeamName = teamCreation[1] });

					Console.WriteLine($"Team {teamName} has been created by {user}!");
				}

				if (isCreated)
				{
					Console.WriteLine($"Team {teamName} was already created!");
				}
			}

			List<JoiningUser> teamsToDisband = new List<JoiningUser>();

			bool isDisband = true;

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
					bool isTeamExisting = teams.Select(x => x.TeamName).Contains(newTeamName);
					bool isCreatorExisting = teams.Select(x => x.User).Contains(newUser);

					isDisband = true;
					if (!isTeamExisting)
					{
						Console.WriteLine($"Team {newTeamName} does not exist!");
						break;
					}
					else if (isCreatorExisting)
					{
						Console.WriteLine($"Member {newUser} cannot join team {newTeamName}!");
						foreach (var item in teams)
						{
							if (teams.Contains(item) && isDisband == true)
							{
								teamsToDisband.Add(new JoiningUser { User = newArray[0], TeamName = newArray[1] });
								break;
							}
						}
						break;
					}
					else
					{
						foreach (var item in teams)
						{
							if (teams.Contains(item) && isDisband == true)
							{
								joining.Add(new JoiningUser { User = newArray[0], TeamName = newArray[1] });
								isDisband = false;
								break;
							}
							else if (!teams.Contains(item) && isDisband == false)
							{
								teamsToDisband.Add(new JoiningUser { User = newArray[0], TeamName = newArray[1] });
							}
						}
						break;
					}
				}
			}

			bool isCreator = false;

			List<string> orderingTeams = new List<string>();
			List<string> newUsers = new List<string>();

			bool isTrue = true;

			foreach (var newTeam in teams)
			{
				newUsers = new List<string>();
				isCreator = false;
				foreach (var item in joining)
				{
					if (item.TeamName == newTeam.TeamName)
					{
						isTrue = true;
						
						Console.WriteLine(newTeam.TeamName);
						break;
					}
				}
				foreach (var creator in joining)
				{
					if (creator.TeamName == newTeam.TeamName)
					{
						isTrue = false;
						isCreator = true;
						Console.WriteLine($"- {newTeam.User}");
						var orderedUserNames = joining.OrderBy(x => joining[0]).ToList();
						foreach (var user in orderedUserNames)
						{
							if (user.TeamName == creator.TeamName)
							{
								Console.WriteLine($"-- {user.User}");
							}
						}
						break;
					}
				}
			}

			Console.WriteLine("Teams to disband: ");
			foreach (var teamToDisband in teamsToDisband)
			{
                Console.WriteLine(teamToDisband.TeamName);
			}
		}
	}

	public class CreatingTeam
	{
		public string User { get; set; }
		public string TeamName { get; set; }

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