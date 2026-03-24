using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Repositories
{
    public class UserRepository: IUserRepository
    {

        private readonly AppDbContext _Context;


        public UserRepository(AppDbContext context) {
        
        _Context = context;
        
        }


        public async Task<bool> ExistAsync(Guid Userid) {


            return await _Context.Users.AnyAsync(x => x.Id == Userid);
        
        
        
        }
        public async Task<IEnumerable<User>> GetAllAsync() { 
        
        return await _Context.Users.ToListAsync();
        
        
        
        
        }
        public async Task<User> AddAsync(User user) { 
        
        
        _Context.Users.Add(user);
            await _Context.SaveChangesAsync();
            return user;

        
        
        
        
        }

        public async Task<User?> GetByIdAsync(Guid id) {


            return await _Context.Users.FirstOrDefaultAsync(x => x.Id == id);
           

        
        
        
        }
        public async Task<User?> GetByEmailAsync(string email) {

           var user= await _Context.Users.FirstOrDefaultAsync(x=> x.Email.Value==email);
        
        return user;
        
        
        }
        public async Task SaveChangesAsync() { 
        
        
        await _Context.SaveChangesAsync();
           
        
        }

        

    }
}
