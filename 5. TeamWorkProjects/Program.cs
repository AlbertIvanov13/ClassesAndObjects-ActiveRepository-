namespace _5._TeamWorkProjects
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int registeredTeamCount = int.Parse(Console.ReadLine());

			CreatingTeam team = new CreatingTeam();

			string[] teamCreation = { };

			teamCreation = Console.ReadLine().Split("-").ToArray();

			List<CreatingTeam> teams = new List<CreatingTeam>();
			teams.Add(new CreatingTeam { User = teamCreation[0], TeamName = teamCreation[1] });

			for (int i = 0; i < registeredTeamCount; i++)
			{
				Console.WriteLine(teams[i].ToString());
				teamCreation = Console.ReadLine().Split("-").ToArray();
				teams.Add(new CreatingTeam { User = teamCreation[0], TeamName = teamCreation[1] });
				for (int j = 0; j < teams.Count; j++)
				{
					if (teams[i].TeamName == teamCreation[1])
					{
                        Console.WriteLine($"Team {teams[i].TeamName} was already created!");
					}
				}
			}

			string[] newArray = { };

			newArray = Console.ReadLine().Split("->").ToArray();

			while (newArray[0] != "end of assignment")
			{
				for (int i = 0; i < teams.Count; i++)
				{
					if (teams[i].User == newArray[0])
					{
						Console.WriteLine($"{teams[i]} user cannot create another team!");
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
	}
}