using Microsoft.AspNetCore.Mvc;
using Contexts;
using Models;
namespace Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly Data _db;
    public EmployeeController(Data db)
    {
        _db = db;
    }

    //representerar data som ska skickas till API:
    public record CreateEmployeeRequestDto(string name, double salary);


    [HttpPost]
    public ActionResult<Employee> CreateEmployee([FromBody] CreateEmployeeRequestDto employeeDto)
    {
        Employee employee = new Employee(employeeDto.name, employeeDto.salary);
        _db.Employees.Add(employee);
        _db.SaveChanges();
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }

    [HttpGet]
    public ActionResult<List<Employee>> GetAllEmployees()
    {
        var employees = _db.Employees.OrderBy(e => e.Salary).ToList();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployeeById([FromRoute] int id)
    {
        Employee? employee = _db.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPut("{id}/salary")]
    public ActionResult UpdateEmployeeSalary([FromRoute] int id, [FromBody] double newSalary)
    {
        Employee? employee = _db.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        employee.Salary = newSalary;
        _db.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteById([FromRoute] int id)
    {
        Employee? employee = _db.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        _db.Employees.Remove(employee);
        _db.SaveChanges();
        return Ok();
    }
}
