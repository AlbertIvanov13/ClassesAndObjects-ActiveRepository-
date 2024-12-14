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
					joining.Add(new JoiningUser { User = teamCreation[0], TeamName = teamCreation[1] });

					Console.WriteLine($"Team {teamName} has been created by {user}!");
				}

				if (isCreated)
				{
					Console.WriteLine($"Team {teamName} was already created!");
				}
			}

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

					if (!isTeamExisting)
					{
						Console.WriteLine($"Team {newTeamName} does not exist!");
						break;
					}
					else if (isCreatorExisting)
					{
						Console.WriteLine($"Member {newUser} cannot join team {newTeamName}");
						break;
					}
					else
					{
						joining.Add(new JoiningUser { User = newArray[0], TeamName = newArray[1] });
						break;
					}
				}
			}

			bool isCreator = false;

			List<string> newUsers = new List<string>();

			foreach (var newTeam in teams)
			{
				newUsers = new List<string>();
				isCreator = false;
				Console.WriteLine(newTeam.TeamName);
				foreach (var newUser in joining)
				{
					if (newUser.TeamName == newTeam.TeamName && isCreator == false)
					{
						isCreator = true;
						Console.WriteLine($"-{newUser.User}");
						continue;
					}

					if (isCreator)
					{
						if (newUser.TeamName == newTeam.TeamName)
						{
							newUsers.Add(newUser.User);
						}
					}
				}
				var orderedUserNames = newUsers.OrderBy(x => newUsers[0]).ToList();
				foreach (var user in orderedUserNames)
				{
					Console.WriteLine($"--{user}");
				}
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