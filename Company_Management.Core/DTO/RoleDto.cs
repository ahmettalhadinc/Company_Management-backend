using Company_Management.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Core.DTO
{
    public class RoleDto:BaseDTO
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }


        public DepartmentDto? Department { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
