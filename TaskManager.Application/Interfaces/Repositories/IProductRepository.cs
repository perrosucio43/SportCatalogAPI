using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces.Repositories
{
  public interface IProductRepository
    {


        Task<(List<Product>, int)> GetAllAsync(PaginationParams p);

        Task<Product> AddAsync(Product product);

        Task<bool> CategoryExists(Guid categoryId);
        Task<Product?> GetByIdAsync(Guid id);
        Task<List<Product>> GetAllNoPaginationAsync();
        Task<List<Product>> GetByCategoryAsync(Guid id);
        Task DeleteAsync(Guid id);




    }
}

