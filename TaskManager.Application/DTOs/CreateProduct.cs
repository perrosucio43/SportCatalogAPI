using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.DTOs
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public IFormFile Image { get; set; }
        public Guid CategoryId { get; set; }
        [BindNever]
        public string? ImageUrl { get; set; }
    }
}
