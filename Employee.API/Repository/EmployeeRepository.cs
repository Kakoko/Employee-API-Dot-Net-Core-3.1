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

            return _context.Employees.FirstOrDefault(a => a.Id == employeeId);
        }

        public IEnumerable<Entities.Employee> GetEmployees()
        {
            return _context.Employees.ToList<Entities.Employee>();
        }

        public IEnumerable<Entities.Employee> GetEmployeesByDepartment(Guid departmentId)
        {
            if (departmentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(departmentId));
            }

            return _context.Employees.Where(a => a.DepartmentId == departmentId);
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
