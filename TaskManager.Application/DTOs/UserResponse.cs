using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.ObjectsValues;

namespace TaskManager.Application.DTOs
{
   public  class UserResponse
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }



    }
}
