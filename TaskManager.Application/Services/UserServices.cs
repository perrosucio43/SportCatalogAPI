using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Application.Mappings;
using TaskManager.Domain.Entities;
using TaskManager.Domain.ObjectsValues;

namespace TaskManager.Application.Services
{
    public class UserServices : IUserService
    {

        private readonly IUserRepository _UserRepository;
        public UserServices(IUserRepository userRepository) {

            _UserRepository = userRepository;


        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync() {

            var users = await _UserRepository.GetAllAsync();
            if (users == null) return null;

            return users.TOResponseDTOE();
        }


        public async Task<bool> ExistAsync(Guid id) {

            return await _UserRepository.ExistAsync(id);



        }
        public async Task<UserResponse> CreateAsync(CreateUserDTO userDTO) {
            var email = Email.Create(userDTO.Email);
            var passwordValid = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            var user = new User(userDTO.Name, email, passwordValid, userDTO.role);

           var createUser=  await _UserRepository.AddAsync(user);
            return createUser.ToResponseDTO();




        }
      
        public async Task<UserResponse?> GetByIdAsync(Guid id) {


            var user= await _UserRepository.GetByIdAsync(id);

            if (user == null)  return null;
            return user.ToResponseDTO();
        
        }
        public async Task<UserResponse?> UpdateAsync(Guid id, UpdateUserDTO dto) {


            var update = await _UserRepository.GetByIdAsync(id);
            if (update == null) return null;
            if(string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name is required");
            if (string.IsNullOrWhiteSpace(dto.Email)) throw new ArgumentException("Email is required");
            update.ChangeName(dto.Name);
            var email=Email.Create(dto.Email);
            update.ChangeEmail(email);

            await _UserRepository.SaveChangesAsync();

            return update.ToResponseDTO();
                
            




        }
        public async Task<UserResponse?> GetByEmailAsync(LoginDto dto) {

            var user = await _UserRepository.GetByEmailAsync(dto.Email);
            
            if(user==null){ 
            
            return null;
            
            
            
            }
            var validpass = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);


            if (!validpass) { 
            return null;
            
            
            }
        
            return user.ToResponseDTO();
        
        }

        


    }
}
