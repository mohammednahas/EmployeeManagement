namespace EmployeeManagement.Application.DTOs.Employees;

public class EmployeeDto
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;
}