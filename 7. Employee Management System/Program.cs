namespace _7._Employee_Management_System
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Department department = new Department();
			Employee employee = new Employee("John", 1, Convert.ToDecimal(75.000), "IT");

			department.Employees.Add(employee);
			for (int i = 0; i < department.Employees.Count; i++)
			{
				Console.Write(employee.Name + " ");
				Console.Write(employee.Id + " ");
				Console.Write($"{employee.Salary:f3}" + " ");
				Console.Write(employee.Department);
			}
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

			}
		}
	}
}