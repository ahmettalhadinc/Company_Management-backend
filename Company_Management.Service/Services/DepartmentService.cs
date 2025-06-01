using Company_Management.Core.Models;
using Company_Management.Core.Repository;
using Company_Management.Core.Services;
using Company_Management.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Service.Services
{
    public class DepartmentService(IGenericRepository<Department> repository, IUnitOfWorks unitOfWorks,IDepartmentRepository departmentRepository) : Service<Department>(repository, unitOfWorks), IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository=departmentRepository;
    }
}
