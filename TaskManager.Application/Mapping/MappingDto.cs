using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Mappings
{
    public static class MappingDto
    {




        public static UserResponse ToResponseDTO( this User user) {



            return new UserResponse {Id=user.Id, Email=user.Email.Value, Name=user.Name, Role=user.Role };
        
        
        
        
        }
        public static ProductResponseDTO ToResponseProductDTO(this Product pro)
        {



        return new ProductResponseDTO {  
        id=pro.Id,
        Name = pro.Name,
        Price = pro.Price,
        ImageUrl = pro.ImageUrl,
        Category = pro.Category?.Name ?? string.Empty



        };




        }

        public static IEnumerable<ProductResponseDTO> ToResponseProductsDTO(this IEnumerable<Product> p)
        {

            return p.Select(z => z.ToResponseProductDTO());




        }

        public static IEnumerable<UserResponse> TOResponseDTOE(this IEnumerable<User> users) {

            return users.Select(z=>z.ToResponseDTO());
        
        
        
        
        }


    }
}
