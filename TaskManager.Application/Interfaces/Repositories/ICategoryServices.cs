using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces.Repositories
{
   
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryResponseDTO>> GetAllAsync();

        Task<CategoryResponseDTO> CreateAsync(CreateCategoryDTO dto);

      
        
            Task<Category?> GetByIdAsync(Guid id);
        
    }
}

