using EmployeeManagement.Application.DTOs.Employees;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Web.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    public EmployeeController(
        IEmployeeService employeeService,
        IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
    }

    // GET: /Employee
    public async Task<IActionResult> Index()
    {
        var employees = await _employeeService.GetAllAsync();

        return View(employees);
    }

    // GET: /Employee/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);

        if (employee == null)
            return NotFound();

        return View(employee);
    }

    // GET: /Employee/Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await LoadDepartments();

        return View();
    }

    // POST: /Employee/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateEmployeeDto dto)
    {
        if (!ModelState.IsValid)
        {
            await LoadDepartments();
            return View(dto);
        }

        await _employeeService.CreateAsync(dto);

        return RedirectToAction(nameof(Index));
    }

    // GET: /Employee/Edit/5
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);

        if (employee == null)
            return NotFound();

        var dto = new UpdateEmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            Name = employee.Name,
            Salary = employee.Salary,
            DepartmentId = employee.DepartmentId
        };

        await LoadDepartments();

        return View(dto);
    }

    // POST: /Employee/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateEmployeeDto dto)
    {
        if (!ModelState.IsValid)
        {
            await LoadDepartments();
            return View(dto);
        }

        var updated = await _employeeService.UpdateAsync(dto);

        if (!updated)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }

    // GET: /Employee/Delete/5
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);

        if (employee == null)
            return NotFound();

        return View(employee);
    }

    // POST: /Employee/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var deleted = await _employeeService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadDepartments()
    {
        var departments = await _departmentService.GetAllAsync();

        ViewBag.Departments = new SelectList(
            departments,
            "DepartmentId",
            "Name");
    }
}