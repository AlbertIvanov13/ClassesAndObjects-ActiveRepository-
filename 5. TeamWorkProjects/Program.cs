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

			string[] teamCreation = { };

			teamCreation = Console.ReadLine().Split("-").ToArray();

			List<CreatingTeam> teams = new List<CreatingTeam>();
			List<JoiningUser> joining = new List<JoiningUser>();
			teams.Add(new CreatingTeam { User = teamCreation[0], TeamName = teamCreation[1] });

			int encounter = 0;

			for (int i = 0; i < registeredTeamCount - 1; i++)
			{
				teamCreation = Console.ReadLine().Split("-").ToArray();
				for (int j = 0; j < teams.Count; j++)
				{
					if (teams[j].TeamName == teamCreation[1])
					{
						encounter++;
					}

					if (encounter > 1)
					{
						Console.WriteLine($"Team {joining[i].TeamName} was already created!");
					}
					else
					{
						teams.Add(new CreatingTeam { User = teamCreation[0], TeamName = teamCreation[1] });
						encounter = 0;
					}
					break;
				}
			}

			string[] newArray = { };

			newArray = Console.ReadLine().Split("->").ToArray();

			bool isFoundTeamName = false;
			bool isFoundUserName = false;

			string[] members = { };
			joining.Add(new JoiningUser { User = newArray[0], TeamName = newArray[1] });

			while (newArray[0] != "end of assignment")
			{
				newArray = Console.ReadLine().Split("->").ToArray();
				if (newArray[0] != "end of assignment")
				{
					joining.Add(new JoiningUser { User = newArray[0], TeamName = newArray[1] });
				}
			}

			for (int i = 0; i < teams.Count; i++)
			{
				Console.WriteLine(teams[i].ToString());

				for (int j = 0; j < joining.Count; j++)
				{
					if (joining[j].TeamName == teams[i].TeamName)
					{
						//if (joining[j].TeamName == teams[i].TeamName)
						//{
						//	Console.WriteLine($"Team {joining[i].TeamName} was already created!");
						//}

						if (teams[i].User == joining[j].User)
						{
							Console.WriteLine($"{teams[i].User} cannot create another team!");
						}

						if (joining[j].User == teams[i].User && joining[j].TeamName == teams[i].TeamName)
						{
							Console.WriteLine($"Member {joining[j].User} cannot join team {teams[i].TeamName}!");
						}
					}
					else
					{
						if (i == teams.Count)
						{
                            Console.WriteLine($"Team {joining[j].TeamName} does not exist!");
						}
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
}