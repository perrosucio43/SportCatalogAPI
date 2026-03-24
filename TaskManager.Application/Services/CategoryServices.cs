using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services
{

    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();

            return categories.Select(c => new CategoryResponseDTO
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<CategoryResponseDTO> CreateAsync(CreateCategoryDTO dto)
        {
            var category = new Category(dto.Name);
           

            var created = await _repository.AddAsync(category);

            return new CategoryResponseDTO
            {
                Id = created.Id,
                Name = created.Name
            };
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
