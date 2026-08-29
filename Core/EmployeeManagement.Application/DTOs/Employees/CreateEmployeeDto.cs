namespace EmployeeManagement.Application.DTOs.Employees;

public class CreateEmployeeDto
{
    public string Name { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }
}