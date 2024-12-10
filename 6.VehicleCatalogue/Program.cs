namespace _6.VehicleCatalogue
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] array = { };

			array = Console.ReadLine().Split(" ").ToArray();

			double carsHorsePowerCount = 0;

			double carsTotalHorsePower = 0;

			double trucksHorsePowerCount = 0;

			double trucksTotalHorsePower = 0;

			Vehicle vehicle = new Vehicle();

			List<Vehicle> list = new List<Vehicle>();

			if (array[0] == "car" || array[0] == "truck")
			{
				list.Add(new Vehicle { Type = array[0], Model = array[1], Color = array[2], HorsePower = Convert.ToDouble(array[3]) });
			}

			if (array[0] == "car")
			{
				carsHorsePowerCount++;
				carsTotalHorsePower += Convert.ToDouble(array[3]);
			}
			else if (array[0] == "truck")
			{
				trucksHorsePowerCount++;
				trucksTotalHorsePower += Convert.ToDouble(array[3]);
			}

			while (array[0] != "End")
			{
				array = Console.ReadLine().Split(" ").ToArray();

				if (array[0] != "End")
				{
					if (array[0] == "car" || array[0] == "truck")
					{
						list.Add(new Vehicle { Type = array[0], Model = array[1], Color = array[2], HorsePower = Convert.ToDouble(array[3]) });
						for (int i = 0; i < list.Count; i++)
						{
							if (list[i].Model == array[1])
							{
								break;
							}
						}
					}
					if (array[0] == "car")
					{
						carsHorsePowerCount++;
						carsTotalHorsePower += Convert.ToDouble(array[3]);
					}
					else if (array[0] == "truck")
					{
						trucksHorsePowerCount++;
						trucksTotalHorsePower += Convert.ToDouble(array[3]);
					}
				}
			}

			string input = Console.ReadLine();

			while (input != "Close the Catalogue")
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (input == list[i].Model)
					{
						if (list[i].Type == "car")
						{
							Console.WriteLine($"Type: Car");
						}
						else if (list[i].Type == "truck")
						{
							Console.WriteLine($"Type: Truck");
						}
						Console.WriteLine($"Model: {list[i].Model}");
						Console.WriteLine($"Color: {list[i].Color}");
						Console.WriteLine($"Horsepower: {list[i].HorsePower}");
					}
				}
				input = Console.ReadLine();
			}

			Console.WriteLine($"Cars have average horsepower of: {carsTotalHorsePower / carsHorsePowerCount:f2}.");

			Console.WriteLine($"Trucks have average horsepower of: {trucksTotalHorsePower / trucksHorsePowerCount:f2}.");

		}

		public class Vehicle
		{
			public string Type { get; set; }
			public string Model { get; set; }
			public string Color { get; set; }
			public double HorsePower { get; set; }
		}
	}
}