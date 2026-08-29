using EmployeeManagement.Application.DTOs.Employees;

namespace EmployeeManagement.Application.Interfaces;

public interface IEmployeeService
{
    Task<int> CreateAsync(CreateEmployeeDto dto);

    Task<List<EmployeeDto>> GetAllAsync();

    Task<EmployeeDto?> GetByIdAsync(int id);

    Task<bool> UpdateAsync(UpdateEmployeeDto dto);

    Task<bool> DeleteAsync(int id);
}