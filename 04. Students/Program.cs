namespace _04._Students
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int studentsCount = int.Parse(Console.ReadLine());

			List<string> newStudent = new List<string>();
			List<Student> newStudentList = new List<Student>();
			for (int i = 0; i < studentsCount; i++)
			{
				newStudent = Console.ReadLine().Split(" ").ToList();

				newStudentList.Add(new Student { FirstName = newStudent[0], LastName = newStudent[1], Grade = Convert.ToDecimal(newStudent[2]) });
			}

			var orderedStudents = newStudentList.OrderByDescending(x => x.Grade).ToList();
			foreach (var student in orderedStudents)
			{
				Console.WriteLine(student.ToString());
			}
		}

		public class Student
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public decimal Grade { get; set; }


			public override string ToString()
			{
				return $"{FirstName} {LastName}: {Grade}";
			}
		}
	}
}