using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.API.Entities;
using Employee.API.ResourceParamemters;

namespace Employee.API.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Entities.Employee> GetEmployeesByDepartment(Guid departmentId);
        IEnumerable<Entities.Employee> GetEmployees();
        IEnumerable<Entities.Employee> GetEmployees(EmployeeResourceParameter employeeResourceParameter);
        IEnumerable<Department> GetDepartments();
        Entities.Employee GetEmployee(Guid employeeId);
        bool EmployeeExists(Guid employeeId);
        bool DepartmentExists(Guid departmentId);
        string GetDepartment(Guid departmentId);
        Entities.Employee GetEmployeeByDepartment(Guid departmentId);
        bool Save();
    }
}
