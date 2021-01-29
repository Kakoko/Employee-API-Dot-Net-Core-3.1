using AutoMapper;
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
    [Route("api/employess/{departmentId}/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public DepartmentsController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ??
                throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDTO>> GetEmployeesByDepartment(Guid departmentId)
        {
            if (!_employeeRepository.DepartmentExists(departmentId))
            {
                return NotFound();
            }

            var employeesByDepartmentFromRepo = _employeeRepository.GetEmployeesByDepartment(departmentId);

            return Ok(_mapper.Map<IEnumerable<DepartmentDTO>>(employeesByDepartmentFromRepo));
        }

        [HttpGet("{employeeId}")]
        public ActionResult<DepartmentDTO> GetEmployeeByDepartment(Guid departmentId , Guid employeeId)
        {
            if(!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();;
            }

            var employeeFromEmployeeRepo = _employeeRepository.GetEmployeeByDepartment(departmentId);

            if(employeeFromEmployeeRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DepartmentDTO>(employeeFromEmployeeRepo));
        }
    }
}
