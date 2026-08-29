namespace EmployeeManagement.Domain.Entities;

public class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; private set; } = string.Empty;

    public decimal Salary { get;  private set; }

    public int DepartmentId { get; private set; }

    public Department Department { get; set; } = null!;

 private Employee()
    {
    }
     public Employee(string name, decimal salary, int departmentId)
    {
        SetName(name);
        SetSalary(salary);
        SetDepartment(departmentId);
        System.Console.WriteLine("I used Rich model");
    }

    public void Update(
        string name,
        decimal salary,
        int departmentId)
    {
        SetName(name);
        SetSalary(salary);
        SetDepartment(departmentId);
        System.Console.WriteLine("I used Rich model to update emp");
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Employee name is required.");
        System.Console.WriteLine("I used Rich model to set emp name");

        Name = name;
    }

    private void SetSalary(decimal salary)
    {
        if (salary < 0)
            throw new ArgumentException("Salary cannot be negative.");
        System.Console.WriteLine("I used Rich model to set emp salary");    
            

        Salary = salary;
    }

    private void SetDepartment(int departmentId)
    {
        if (departmentId <= 0)
            throw new ArgumentException("Invalid department.");
        System.Console.WriteLine("I used Rich to set emp dep");    

        DepartmentId = departmentId;
    }
}