using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Core.Models
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
    
        public int RoleId { get; set; }

        public bool IsWorking { get; set; }

        public Role Role { get; set; }


    }
}
