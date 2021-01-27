using AutoMapper;
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

    }
}
