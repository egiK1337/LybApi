﻿using DataLayer.EfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BookServices.Concrete
{
    public class BookDeleteService
    {
        private readonly EfCoreContext _context;

        public BookDeleteService(EfCoreContext context) 
        {
            _context = context;
        }
    }
}
