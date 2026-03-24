using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces.Repositories
{
    public interface IProductServices
    {

        Task<PagedResult<ProductResponseDTO>> GetAllAsync(PaginationParams p);

        Task<ProductResponseDTO> CreateAsync(CreateProductDTO dto);
        Task<ProductResponseDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductResponseDTO>> GetAllNoPaginationAsync();
        Task<IEnumerable<ProductResponseDTO>> GetByCategoryAsync(Guid categoryId);
        Task DeleteProductAsync(Guid id);

    }
}
