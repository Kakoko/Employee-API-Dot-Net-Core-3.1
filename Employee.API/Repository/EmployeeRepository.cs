using Employee.API.DBContext;
using Employee.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {

        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public EmployeeRepository()
        {
        }

        public bool EmployeeExists(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

           
            return _context.Employees.Any(a => a.Id == employeeId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList<Department>();
        }

        public Entities.Employee GetEmployee(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }


            var employeeFromRepo = _context.Employees.FirstOrDefault(a => a.Id == employeeId);
            var employeeWithDepartment = new Entities.Employee()
            {
                Id = employeeFromRepo.Id,
                FirstName = employeeFromRepo.FirstName,
                LastName = employeeFromRepo.LastName,
                DateOfBirth = employeeFromRepo.DateOfBirth,
                DepartmentId = employeeFromRepo.DepartmentId,
                Department = _context.Departments.FirstOrDefault(u => u.Id == employeeFromRepo.DepartmentId)
            } ;

           

            return employeeWithDepartment;
        }

        public IEnumerable<Entities.Employee> GetEmployees()
        {
            var employeesFromRepo =  _context.Employees.ToList<Entities.Employee>();
            var employeesWithDepartmentName = new List<Entities.Employee>();

            foreach (var employee in employeesFromRepo)
            {
                employeesWithDepartmentName.Add(new Entities.Employee
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    DepartmentId = employee.DepartmentId,
                    Department = _context.Departments.FirstOrDefault(u => u.Id == employee.DepartmentId)

                });
            }
            return employeesWithDepartmentName;
        }

        public IEnumerable<Entities.Employee> GetEmployeesByDepartment(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(departmentId));
            }

            return _context.Employees.Where(a => a.DepartmentId == departmentId);
        }


        public string GetDepartment(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(departmentId));
            }

            if (DepartmentExists(departmentId))
            {
                return _context.Departments.FirstOrDefault(a => a.Id == departmentId).DepartmentName;
            }
            throw new Exception();
        }


        public bool DepartmentExists(Guid departmentId)
        {


            var res = false;
            if (departmentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(departmentId));
            }
            
            try
            {
                res = _context.Departments.Any(a => a.Id == departmentId);
            }
            catch (Exception e)
            {

                throw e;
            }
            
            return res;
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

       
    }
}
