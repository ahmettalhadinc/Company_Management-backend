using AutoMapper;
using Company_Management.API.Filters;
using Company_Management.Core.DTO;
using Company_Management.Core.DTO.UpdateDTOs;
using Company_Management.Core.Models;
using Company_Management.Core.Services;
using Microsoft.AspNetCore.Authorization;
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
        [ServiceFilter(typeof(NotFoundFilter<Department>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department= await _departmentService.GetByIdAsync(id);
            var departmentDto= _mapper.Map<DepartmentDto>(department);
            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(200,departmentDto));

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = 4; 
            var department = await _departmentService.GetByIdAsync(id);
            department.UpdatedBy = userId;
            _departmentService.ChangeStatus(department);


            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpPost]
        public async Task<IActionResult> Save (DepartmentDto departmentDto)
        {
            int userId = 4;
            var processedEntity= _mapper.Map<Department>(departmentDto);

            processedEntity.UpdatedBy = userId;
            processedEntity.CreatedBy = userId;


            var department= await _departmentService.AddAsync(processedEntity);
            var departmentResponseDto = _mapper.Map<DepartmentDto>(department);
            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(201, departmentResponseDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DepartmentUpdateDto departmentDto)
        {
            int userId = 4;
            var currentDepartment = await _departmentService.GetByIdAsync(departmentDto.Id);
             currentDepartment.UpdatedBy = userId;
            currentDepartment.Name = departmentDto.Name;

            _departmentService.Update(currentDepartment);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }



    }
}
