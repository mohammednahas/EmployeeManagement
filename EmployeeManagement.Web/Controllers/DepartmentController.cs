using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    // GET: /Department
    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.GetAllAsync();

        return View(departments);
    }

    // GET: /Department/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);

        if (department == null)
            return NotFound();

        return View(department);
    }

    // GET: /Department/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Department/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateDepartmentDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _departmentService.CreateAsync(dto);

        return RedirectToAction(nameof(Index));
    }

    // GET: /Department/Edit/5
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);

        if (department == null)
            return NotFound();

        var dto = new UpdateDepartmentDto
        {
            DepartmentId = department.DepartmentId,
            Name = department.Name,
            Description = department.Description
        };

        return View(dto);
    }

    // POST: /Department/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateDepartmentDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var updated = await _departmentService.UpdateAsync(dto);

        if (!updated)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }

    // GET: /Department/Delete/5
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);

        if (department == null)
            return NotFound();

        return View(department);
    }

    // POST: /Department/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var deleted = await _departmentService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }
}