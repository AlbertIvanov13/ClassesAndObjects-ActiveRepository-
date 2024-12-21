namespace _7._Employee_Management_System
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Department department = new Department();
			Employee employee1 = new Employee("John", 1, Convert.ToDecimal(70.000), "IT");
			department.AddEmployee(employee1);
			Employee employee2 = new Employee("Sarah", 2, Convert.ToDecimal(75.000), "IT");
			department.AddEmployee(employee2);

			department.DisplayEmployees();
		}

		public class Employee
		{
			public string Name { get; set; }
			public int Id { get; set; }
			public decimal Salary { get; set; }
			public string Department { get; set; }

			public Employee(string name, int id, decimal salary, string department)
			{
				Name = name;
				Id = id;
				Salary = salary;
				Department = department;
			}
			public void DisplayDetails()
			{

			}
		}

		public class Department
		{
			public string DepartmentName { get; set; }
			public List<Employee> Employees { get; set; }

			public Department()
			{
				Employees = new List<Employee>();
			}

			public void AddEmployee(Employee employee)
			{
				Employees.Add(employee);
			}

			public void GetTotalSalary()
			{

			}

			public void DisplayEmployees()
			{
				List<string> departments = new List<string> { "IT", "HR" };
				decimal totalSalary = 0;
				foreach (var dep in departments)
				{
					totalSalary = 0;
					Console.WriteLine($"Employees in {dep} department:");
					foreach (Employee employee in Employees)
					{
						if (dep == employee.Department)
						{
							Console.WriteLine($"Name: {employee.Name}, " +
							$"ID: {employee.Id}, " +
							$"Salary: ${employee.Salary:f3}, " +
							$"Department: {employee.Department}");
							totalSalary += Convert.ToDecimal(employee.Salary);
						}
					}
					Console.WriteLine($"Total Salary for {dep} Department: ${totalSalary:f3}\n");
					continue;
				}
			}
		}
	}
}