using AutoMapper;
using Company_Management.API.Filters;
using Company_Management.Core.DTO.UpdateDTOs;
using Company_Management.Core.DTO;
using Company_Management.Core.Models;
using Company_Management.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : CustomBaseController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var employees = _employeeService.GetAll();
            var dtos = _mapper.Map<List<EmployeeDto>>(employees).ToList();
            return CreateActionResult(CustomResponseDto<List<EmployeeDto>>.Success(200, dtos));

        }
        [ServiceFilter(typeof(NotFoundFilter<Employee>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return CreateActionResult(CustomResponseDto<EmployeeDto>.Success(200, employeeDto));

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = 4;
            var employee = await _employeeService.GetByIdAsync(id);
            employee.UpdatedBy = userId;
            _employeeService.ChangeStatus(employee);


            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpPost]
        public async Task<IActionResult> Save(EmployeeDto employeeDto)
        {
            int userId = 4;
            var processedEntity = _mapper.Map<Employee>(employeeDto);

            processedEntity.UpdatedBy = userId;
            processedEntity.CreatedBy = userId;


            var employee = await _employeeService.AddAsync(processedEntity);
            var employeeResponseDto = _mapper.Map<EmployeeDto>(employee);
            return CreateActionResult(CustomResponseDto<EmployeeDto>.Success(201, employeeResponseDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeUpdateDto employeeDto)
        {
            int userId = 4;
            var currentEmployee = await _employeeService.GetByIdAsync(employeeDto.Id);
            currentEmployee.UpdatedBy = userId;
            currentEmployee.Name = employeeDto.Name;

            _employeeService.Update(currentEmployee);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
