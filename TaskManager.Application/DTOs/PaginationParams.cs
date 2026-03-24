using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.DTOs
{
    public class PaginationParams
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        private const int MaxPagesize = 50;



        public int GetpageNumber()
        {

            return PageNumber=Math.Max(PageNumber, 1);

        }


        public int GetPageSize() {
        
        
        
        
        return PageSize > MaxPagesize ? MaxPagesize : PageSize;
        
        
        
        }


    }



}
