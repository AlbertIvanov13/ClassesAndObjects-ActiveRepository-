List<string> phrases = new List<string> { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
List<string> events = new List<string> { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
List<string> authors = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
List<string> cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

int number = int.Parse(Console.ReadLine());

for (int i = 0; i < number; i++)
{
	string newPhrase = string.Empty;
	string newEvent = string.Empty;
	string newAuthor = string.Empty;
	string newCity = string.Empty;

	for (int j = 0; j < phrases.Count;)
	{
		Random randomPhrase = new Random();

		int result = randomPhrase.Next(phrases.Count);

		newPhrase = phrases[result];

		phrases.Remove(newPhrase);
		break;
	}

	for (int j = 0; j < events.Count;)
	{
		Random randomEvent = new Random();

		int result = randomEvent.Next(events.Count);

		newEvent = events[result];

		phrases.Remove(newEvent);
		break;
	}

	for (int j = 0; j < authors.Count;)
	{
		Random author = new Random();

		int result = author.Next(authors.Count);

		newAuthor = authors[result];

		phrases.Remove(newAuthor);
		break;
	}

	for (int j = 0; j < cities.Count;)
	{
		Random city = new Random();

		int result = city.Next(cities.Count);

		newCity = cities[result];

		phrases.Remove(newCity);
		break;
	}
	Console.WriteLine($"{newPhrase} {newEvent} {newAuthor} - {newCity}");
}