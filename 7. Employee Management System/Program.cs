namespace _7._Employee_Management_System
{
	internal class Program
	{
		static void Main(string[] args)
		{

		}

		public class Employee
		{
            public string Name { get; set; }
			public int Id { get; set; }
			public decimal Salary { get; set; }
        }

		public class Department
		{
            public string DepartmentName { get; set; }

            public List<Employee> Employees { get; set; }


        }
	}
}
