using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.API.Entities;

namespace Employee.API.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Entities.Employee> GetEmployeesByDepartment(Guid departmentId);
        IEnumerable<Entities.Employee> GetEmployees();
        IEnumerable<Department> GetDepartments();
        Entities.Employee GetEmployee(Guid employeeId);
        bool EmployeeExists(Guid employeeId);
        bool DepartmentExists(Guid departmentId);
        Department GetDepartment(Guid departmentId);
        bool Save();
    }
}
