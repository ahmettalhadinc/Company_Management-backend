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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWorks unitOfWorks, IProductRepository productRepository) : base(repository, unitOfWorks)
        {
            _productRepository = productRepository;
        }

        public async Task IncreaseStock(Product product)
        {
           var currentProduct= await _productRepository.GetByIdAsync(product.Id);

            currentProduct.Stock += product.Stock;
            Update(currentProduct);

        }

        public async Task DecreaseStock(Product product)
        {
            var currentProduct = await _productRepository.GetByIdAsync(product.Id);

            currentProduct.Stock -= product.Stock;
            Update(currentProduct);

        }


    }
}
