using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Core.Models
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        
        public ICollection<Role> Roles { get; set; }


    }
}
