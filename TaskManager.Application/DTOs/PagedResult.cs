using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.DTOs
{
    public  class PagedResult<T>
    {

        public IEnumerable<T> Items { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }


        public PagedResult(IEnumerable<T> items , int pageNumber, int pageSize, int Total) { 
        
        
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = Total;
        
        
        
        
        
        }






    }
}
