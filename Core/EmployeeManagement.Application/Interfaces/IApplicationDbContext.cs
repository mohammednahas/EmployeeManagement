using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Department> Departments { get; }

    DbSet<Employee> Employees { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}