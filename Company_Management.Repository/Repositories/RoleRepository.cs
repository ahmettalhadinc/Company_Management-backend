using Company_Management.Core.Models;
using Company_Management.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Repository.Repositories
{
    public class RoleRepository(AppDbContext context) : GenericRepository<Role>(context), IRoleRepository
    {
    }
}
