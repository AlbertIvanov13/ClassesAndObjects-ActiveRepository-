using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._DogClass
{
	public class Dog
	{
		public string Name { get; set; }
		public string Breed { get; set; }
		public int Age { get; set; }
		public string Color { get; set; }

		public Dog(string name, string breed, int age, string color)
		{
			this.Name = name;
			this.Breed = breed;
			this.Age = age;
			this.Color = color;
		}

		public string GetName()
		{
			return Name;
		}

		public string GetBreed()
		{
			return Breed;
		}

		public int GetAge()
		{
			return Age;
		}

		public string GetColor()
		{
			return Color;
		}

		public override string ToString()
		{
			return "Hi, my name is " + GetName() + ", my breed is " + GetBreed() + ", my age is " + GetAge() + ", my color is " + GetColor();
		}
	}
}
