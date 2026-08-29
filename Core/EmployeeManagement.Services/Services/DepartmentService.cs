
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
//nahas
public class DepartmentService : IDepartmentService
{
    private readonly IApplicationDbContext _dbcontext;
    public DepartmentService(IApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public async Task<int> CreateAsync(CreateDepartmentDto dto)
    {
        var department = new Department(
        dto.Name,
         dto.Description
        );
        System.Console.WriteLine("I used Rich model");
        _dbcontext.Departments.Add(department);
        await _dbcontext.SaveChangesAsync();
        return department.DepartmentId;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var department = await _dbcontext.Departments
           .FindAsync(id);
        if (department == null)
            return false;

        _dbcontext.Departments.Remove(department);
        await _dbcontext.SaveChangesAsync();
        return true;
    }

    public async Task<List<DepartmentDto>> GetAllAsync()
    {
        return await _dbcontext.Departments
            .Select(d => new DepartmentDto
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name,
                Description = d.Description
            }).ToListAsync();
    }

    public async Task<DepartmentDto?> GetByIdAsync(int id)
    {
        return await _dbcontext.Departments
    .Where(d => d.DepartmentId == id)
    .Select(d => new DepartmentDto
    {
        DepartmentId = d.DepartmentId,
        Name = d.Name,
        Description = d.Description
    }).FirstOrDefaultAsync();
    }


    public async Task<bool> UpdateAsync(UpdateDepartmentDto dto)
    {
        var department = await _dbcontext.Departments
            .FindAsync(dto.DepartmentId);

        if (department == null)
            return false;

        department.Update(dto.Name,dto.Description);
      

        await _dbcontext.SaveChangesAsync();

        return true;
    }
}
