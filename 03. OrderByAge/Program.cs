namespace _03._OrderByAge
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] persons = { };

			persons = Console.ReadLine().Split(" ").ToArray();
			List<Person> list = new List<Person>();

			list.Add(new Person { Name = persons[0], Id = Convert.ToInt32(persons[1]), Age = Convert.ToInt32(persons[2]) });

			while (persons[0] != "End")
			{
				persons = Console.ReadLine().Split(" ").ToArray();

				if (persons[0] != "End")
				{
					list.Add(new Person { Name = persons[0], Id = Convert.ToInt32(persons[1]), Age = Convert.ToInt32(persons[2]) });
				}
			}

			var orderedPersons = list.OrderBy(x => x.Age).ToList();
			foreach (var person in orderedPersons)
			{
				Console.WriteLine(person.ToString());
			}
		}

		class Person
		{
			public string Name { get; set; }

			public int Id { get; set; }

			public int Age { get; set; }

			public override string ToString()
			{
				return $"{Name} with ID: {Id} is {Age} years old.";
			}
		}
	}
}
