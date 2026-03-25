using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Application.Mappings;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _Productrepository;

        public ProductService(IProductRepository repository)
        {
            _Productrepository = repository;
        }

        public async Task<PagedResult<ProductResponseDTO>> GetAllAsync(PaginationParams param)
        {

            var (items, pro) = await _Productrepository.GetAllAsync(param);

            var itemsm = items.ToResponseProductsDTO();

            return new PagedResult<ProductResponseDTO>(
                itemsm,
                param.PageNumber,
                param.PageSize,
                pro);


      }
       

        public async Task<ProductResponseDTO> CreateAsync(CreateProductDTO dto)
        {
            

            var product = new Product(dto.Name, dto.Description, dto.Price, dto.ImageUrl, dto.CategoryId);
          

            await _Productrepository.AddAsync(product);

            return product.ToResponseProductDTO();
           
        }
        public async Task<ProductResponseDTO?> GetByIdAsync(Guid id)
        {
            var product = await _Productrepository.GetByIdAsync(id);

            if (product == null)
                return null;

            return product.ToResponseProductDTO();
        }
        public async Task<IEnumerable<ProductResponseDTO>> GetAllNoPaginationAsync()
        {
            var products = await _Productrepository.GetAllNoPaginationAsync();

            return products.ToResponseProductsDTO();
        }
        public async Task<IEnumerable<ProductResponseDTO>> GetByCategoryAsync(Guid categoryId)
        {
            var products = await _Productrepository.GetByCategoryAsync(categoryId);

            return products.ToResponseProductsDTO();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _Productrepository.DeleteAsync(id);
        }
    }
}
