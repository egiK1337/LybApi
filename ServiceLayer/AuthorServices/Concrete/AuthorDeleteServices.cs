using DataLayer.EfCode;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Validations.AuthorValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AuthorServices.Concrete
{
    public class AuthorDeleteServices
    {
        private readonly EfCoreContext _context;

        public AuthorDeleteServices(EfCoreContext context) 
        {
            _context = context;
        }

        //AuthorValidator validator = new AuthorValidator();

        public AuthorDto Delete(int id)
        {
            if (id < 0) 
            {
                throw new ArgumentException("Invalid value");
            }
          var authorForDelete = _context.Authors.Where(i => i.Id == id).FirstOrDefault();
                
            if (authorForDelete != null) 
            {
                AuthorDto author = new AuthorDto() 
                {
                    Name = authorForDelete.Name,
                    WebUrl = authorForDelete.WebUrl
                };

                _context.Authors.Remove(authorForDelete);
                _context.SaveChanges();
                return author;
            }
            
            return new AuthorDto();
        }
    }
}
