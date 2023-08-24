using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Abstractions.DTO
{
    public class PageDto
    {
        public int PageNum { get; set; }
        public int PageSize { get; set; }

        public PageDto()
        {
                
        }
    }
}
