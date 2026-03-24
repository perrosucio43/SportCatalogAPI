using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;


namespace TaskManager.Application.Services
{
    public interface IUserService
    {


        Task<IEnumerable<UserResponse>> GetAllAsync();
        Task<bool> ExistAsync(Guid id);
        Task<UserResponse> CreateAsync(CreateUserDTO userDTO);
        Task<UserResponse?> GetByIdAsync(Guid id);
        Task<UserResponse?> UpdateAsync(Guid id, UpdateUserDTO dto);

        Task<UserResponse?> GetByEmailAsync(LoginDto dto);
        


    }
}