using EmployeeManagement.Application.DTOs.Departments;
//mohammed nahas
namespace EmployeeManagement.Application.Interfaces;

public interface IDepartmentService
{
    Task<int> CreateAsync(CreateDepartmentDto dto);

    Task<List<DepartmentDto>> GetAllAsync();

    Task<DepartmentDto?> GetByIdAsync(int id);

    Task<bool> UpdateAsync(UpdateDepartmentDto dto);

    Task<bool> DeleteAsync(int id);
}
