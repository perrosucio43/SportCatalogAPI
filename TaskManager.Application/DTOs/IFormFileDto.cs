using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TaskManager.Application.DTOs
{
    public class UploadImageDTO
    {
        public IFormFile File { get; set; }
    }
}
