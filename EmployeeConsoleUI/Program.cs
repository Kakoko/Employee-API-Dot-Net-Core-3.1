using Employee.API.Helpers;
using Employee.API.Models;
using Employee.API.Repository;
using System;

namespace EmployeeConsoleUI
{
    class Programs
    {


       

        static void Main(string[] args)
        {
         IEmployeeRepository _employeeRepository = new EmployeeRepository();
        DatabaseExtensionMethods databaseExtensionMethods = new DatabaseExtensionMethods(_employeeRepository);

            var res = databaseExtensionMethods.GetDepartmentName(Guid.Parse("D173E20D-159E-4127-9CE9-B0AC2564AD97"));
     Console.WriteLine(res);
        //var employeeFromRepo = employeeRepository.GetEmployee(Guid.Parse("D28888E9-2BA9-473A-A40F-E38CB54F9B35"));

        //    if (employeeFromRepo == null)
        //    {
        //        throw new ArgumentNullException(nameof(employeeFromRepo)); ;
        //    }

        //    var employee = new EmployeeDTO()
        //    {

        //        Id = employeeFromRepo.Id,
        //        Name = $"{employeeFromRepo.FirstName} {employeeFromRepo.LastName}",
        //        Age = employeeFromRepo.DateOfBirth.GetCurrentAge(),
        //        Department = employeeRepository.GetDepartment(employeeFromRepo.DepartmentId).DepartmentName
        //    };


        //    Console.WriteLine(employee.Name);

        //    //IEmployeeRepository employeeRepository = new EmployeeRepository();

            //var res = employeeRepository.DepartmentExists(Guid.Parse("40FF5488-FDAB-45B5-BC3A-14302D59869A"));

            //Console.WriteLine(res);
        }
    }
}
