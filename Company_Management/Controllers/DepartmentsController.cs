using AutoMapper;
using Company_Management.Core.DTO;
using Company_Management.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : CustomBaseController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var departments= _departmentService.GetAll();
            var dtos=_mapper.Map<List<DepartmentDto>>(departments).ToList();
         return CreateActionResult(CustomResponseDto<List<DepartmentDto>>.Success(200, dtos));
           
        }
    }
}
