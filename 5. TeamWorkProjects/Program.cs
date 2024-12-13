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

					Console.WriteLine($"Team {teamName} has been created by {user}!");
				}

				if (isCreated)
				{
					Console.WriteLine($"Team {teamName} was already created!");
				}
			}

			string[] newArray = { };

			newArray = Console.ReadLine().Split("->").ToArray();

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