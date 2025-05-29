using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Core.Models
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }


        public Department Department { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
