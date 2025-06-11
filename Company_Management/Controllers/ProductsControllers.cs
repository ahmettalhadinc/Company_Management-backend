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
    public class ProductsControllers : CustomBaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsControllers(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = _productService.GetAll();
            var dtos = _mapper.Map<List<ProductDto>>(products).ToList();
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, dtos));

        }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = 4;
            var product = await _productService.GetByIdAsync(id);
            product.UpdatedBy = userId;
            _productService.ChangeStatus(product);


            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            int userId = GetUserFromToken();
            var processedEntity = _mapper.Map<Product>(productDto);

            processedEntity.UpdatedBy = userId;
            processedEntity.CreatedBy = userId;


            var product = await _productService.AddAsync(processedEntity);
            var productResponseDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productResponseDto));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> IncreaseStock(ProductDto productDto)
        {
            int userId = 4;
            var processedEntity = _mapper.Map<Product>(productDto);

            processedEntity.UpdatedBy = userId;
            processedEntity.CreatedBy = userId;


             await _productService.IncreaseStock(processedEntity);
            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DecreaseStock(ProductDto productDto)
        {
            int userId = GetUserFromToken();
            var processedEntity = _mapper.Map<Product>(productDto);

            processedEntity.UpdatedBy = userId;
            processedEntity.CreatedBy = userId;


            await _productService.DecreaseStock(processedEntity);
        
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            int userId = 4;
            var currentProduct = await _productService.GetByIdAsync(productDto.Id);
            currentProduct.UpdatedBy = userId;
            currentProduct.Name = productDto.Name;

            _productService.Update(currentProduct);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
