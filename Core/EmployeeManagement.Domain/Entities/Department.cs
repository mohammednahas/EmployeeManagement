namespace EmployeeManagement.Domain.Entities;

public class Department
{
    public int DepartmentId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    private readonly List<Employee> _employees = new();

    public IReadOnlyCollection<Employee> Employees =>
        _employees.AsReadOnly();

 
    private Department()
    {
    }

    public Department(
        string name,
        string description)
    {
        SetName(name);
        SetDescription(description);
    }

    public void Update(
        string name,
        string description)
    {
        SetName(name);
        SetDescription(description);
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Department name is required.");

        Name = name.Trim();
    }

    private void SetDescription(string description)
    {
        Description = description?.Trim() ?? string.Empty;
    }
}