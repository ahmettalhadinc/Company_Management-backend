using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Core.DTO.UpdateDTOs
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsWorking { get; set; }
    }
}
