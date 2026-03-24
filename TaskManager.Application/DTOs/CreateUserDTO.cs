using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.DTOs
{
    public class CreateUserDTO
    {
       
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }= string.Empty; 
        public string Password { get; set; } 
        public string? role { get; set; }
        
       
    }
}
