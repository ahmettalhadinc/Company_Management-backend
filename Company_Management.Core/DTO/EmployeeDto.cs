using Company_Management.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Core.DTO
{
    public class EmployeeDto:BaseDTO
    {
        public string Name { get; set; }

        public int RoleId { get; set; }

        public bool IsWorking { get; set; }

        public RoleDto? Role { get; set; }
    }
}
