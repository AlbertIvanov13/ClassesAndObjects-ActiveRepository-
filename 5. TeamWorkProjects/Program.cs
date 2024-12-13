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
			Console.WriteLine(teams[0].ToString());

			int encounter = 1;
			int n = 0;
			bool isNotFound = false;

			for (int i = 1; i < registeredTeamCount; i++)
			{
				for (int j = n; j < teams.Count; j++)
				{
					if (teams.Contains(teams[j]))
					{
                        Console.WriteLine($"Team {teams[j].TeamName} already exists!");
						n++;
					}
					else
					{
						teams.Add(new CreatingTeam { User = teamCreation[0], TeamName = teamCreation[1] });
						Console.WriteLine(teams[j].ToString());
						n++;
					}
				}
			}

			//for (int i = 0; i < registeredTeamCount - 1; i++)
			//{
			//	teamCreation = Console.ReadLine().Split("-").ToArray();
			//	for (int j = 0; j < teams.Count; j++)
			//	{
			//		if (teams[j].TeamName == teamCreation[1])
			//		{
			//			encounter++;
			//		}

			//		if (encounter > 1)
			//		{
			//			Console.WriteLine($"Team {teams[i].TeamName} was already created!");
			//			encounter = 0;
			//		}
			//		else
			//		{
			//			teams.Add(new CreatingTeam { User = teamCreation[0], TeamName = teamCreation[1] });
			//			encounter = 0;
			//			Console.WriteLine(teams[i].ToString());
			//		}
			//		break;
			//	}
			//}
			string[] newArray = { };

			newArray = Console.ReadLine().Split("->").ToArray();

			bool isFoundTeamName = false;
			bool isFoundUserName = false;

			bool isTrue = false;

			int counter = 0;

			string[] members = { };
			joining.Add(new JoiningUser { User = newArray[0], TeamName = newArray[1] });

			for (int i = 0; i < teams.Count; i++)
			{
				for (int j = 0; j < joining.Count; j++)
				{
					if (teams[i].TeamName == joining[j].TeamName)
					{
						joining.Add(new JoiningUser { User = newArray[0], TeamName = newArray[1] });
						break;
					}
					else
					{
						Console.WriteLine($"Team {joining[j].TeamName} does not exist!");
						break;
					}
				}
				break;
			}

			while (newArray[0] != "end of assignment")
			{
				newArray = Console.ReadLine().Split("->").ToArray();
				if (newArray[0] != "end of assignment")
				{
					joining.Add(new JoiningUser { User = newArray[0], TeamName = newArray[1] });

					for (int i = 0; i < teams.Count; i++)
					{
						for (int j = 0; j < joining.Count; j++)
						{
							if (teams[i].TeamName != joining[j].TeamName)
							{
								counter++;
							}

							if (counter == joining.Count)
							{
								Console.WriteLine($"Team {joining[j].TeamName} does not exist!");
							}
						}
					}
					for (int i = 0; i < teams.Count; i++)
					{
						for (int j = 0; j < joining.Count; j++)
						{
							if (joining[j].TeamName == teams[i].TeamName)
							{
								if (teams[i].User == joining[j].User)
								{
									Console.WriteLine($"{teams[i].User} cannot create another team!");
									break;
								}

								if (joining[j].User == teams[i].User && joining[j].TeamName == teams[i].TeamName)
								{
									Console.WriteLine($"Member {joining[j].User} cannot join team {teams[i].TeamName}!");
									break;
								}
							}
							else
							{

							}
						}
					}
				}
			}

			bool isDisband = false;

			for (int i = 0; i < teams.Count; i++)
			{
				for (int j = 0; j < joining.Count; j++)
				{
					if (joining[j].User == teams[i].User && joining[j].TeamName == teams[i].TeamName)
					{
						isDisband = true;
					}
					else if (joining[j].User != teams[i].User)
					{
						Console.WriteLine($"{teams[i].TeamName}");
						Console.WriteLine($"- {teams[i].User}");
						for (int k = 0; k < joining.Count; k++)
						{
							Console.WriteLine($"-- {joining[i].User}");
							break;
						}
					}
					i++;

					if (isDisband)
					{
						Console.WriteLine("Teams to disband:");
						Console.WriteLine($"{joining[j].TeamName}");
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