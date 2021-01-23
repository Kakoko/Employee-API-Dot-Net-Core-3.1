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
        public IActionResult GetEmployee()
        {
            var employeesFromRepo = _employeeRepository.GetEmployees();
            return Ok(employeesFromRepo);
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
