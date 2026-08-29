using EmployeeManagement.Application.DTOs.Employees;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IApplicationDbContext _dbcontext;

    public EmployeeService(IApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<int> CreateAsync(CreateEmployeeDto dto)
    {
        var employee = new Employee(
      
         dto.Name,
            dto.Salary,
        dto.DepartmentId
        );
        

        _dbcontext.Employees.Add(employee);

        await _dbcontext.SaveChangesAsync();

        return employee.EmployeeId;
    }

    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        return await _dbcontext.Employees
            .Include(e => e.Department)
            .Select(e => new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department.Name
            })
            .ToListAsync();
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        return await _dbcontext.Employees
            .Include(e => e.Department)
            .Where(e => e.EmployeeId == id)
            .Select(e => new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department.Name
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateAsync(UpdateEmployeeDto dto)
    {
        var employee = await _dbcontext.Employees
            .FindAsync(dto.EmployeeId);

        if (employee == null)
            return false;

        employee.Update(
            dto.Name, 
            dto.Salary, 
            dto.DepartmentId);

        await _dbcontext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var employee = await _dbcontext.Employees
            .FindAsync(id);

        if (employee == null)
            return false;

        _dbcontext.Employees.Remove(employee);

        await _dbcontext.SaveChangesAsync();

        return true;
    }
}