using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;
namespace TaskManager.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ExistAsync(Guid userId);
        Task<IEnumerable<User>>GetAllAsync();
        Task<User> AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
        Task<User?> GetByEmailAsync(string email);
        
       
    }
}
