using Employee.API.Helpers;
using Employee.API.Models;
using Employee.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? 
                throw new ArgumentNullException(nameof(employeeRepository));
        }


        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employeesFromRepo = _employeeRepository.GetEmployees();
            var employees = new List<EmployeeDTO>();

            foreach (var employee in employeesFromRepo)
            {
                employees.Add(new EmployeeDTO()
                {
                    Id = employee.Id,
                    Name = $"{employee.FirstName} {employee.LastName}",
                    Age = employee.DateOfBirth.GetCurrentAge(),
                    Department = _employeeRepository.GetDepartment(employee.DepartmentId).DepartmentName

                }) ;
            }
            return Ok(employees);
        }


        [HttpGet("{employeeId}")]
        public IActionResult GetEmployee(Guid employeeId)
        {
            var employeeFromRepo = _employeeRepository.GetEmployee(employeeId);

            if(employeeFromRepo == null)
            {
                return NotFound();
            }
            return Ok(employeeFromRepo);
        }
    }
}
