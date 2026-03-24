using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces.Repositories
{
   
        public interface ICategoryRepository
        {
            Task<List<Category>> GetAllAsync();

            Task<Category> AddAsync(Category category);

      
            Task<Category?> GetByIdAsync(Guid id);
        
    }
    
}
