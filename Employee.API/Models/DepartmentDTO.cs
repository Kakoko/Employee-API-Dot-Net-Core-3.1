using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Models
{
    public class DepartmentDTO
    {
        public string DepartmentName { get; set; }
        public ICollection<Entities.Employee> Employees { get; set; }
         = new List<Entities.Employee>();
    }
}
