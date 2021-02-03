using AutoMapper;
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
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository , IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? 
                throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<EmployeeDTO>> GetEmployees([FromQuery]string departmentName,
            [FromQuery]string searchQuery)
        {

            //throw new Exception("Test");
            var employeesFromRepo = _employeeRepository.GetEmployees(departmentName , searchQuery);
            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(employeesFromRepo));
        }


        [HttpGet("{employeeId}")]
        public ActionResult<EmployeeDTO> GetEmployee(Guid employeeId)
        {
            var employeeFromRepo = _employeeRepository.GetEmployee(employeeId);

            if(employeeFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmployeeDTO>(employeeFromRepo));
        }
    }
}
