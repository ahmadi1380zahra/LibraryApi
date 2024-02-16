using Library.Entities;
using Library.Services.Authors.Contracts;
using Library.Services.Authors.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Persistance.EF.Authors
{
    public class EFAuthorRepository : AuthorRepository
    {
        private readonly EFDataContext _context;
       
        public EFAuthorRepository(EFDataContext context)
        {
            _context=context;
        }
        public void Add(Author author)
        {
             _context.Authors.Add(author);
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
        }

        public List<GetAuthorDto> GetAll(GetAuthorFilterDto dto)
        {
            IQueryable<Author> query = _context.Authors;
            if (!string.IsNullOrWhiteSpace(dto.FullName))
            {
                query = query.Where(_ => _.FullName.Contains(dto.FullName));
            }
            List<GetAuthorDto> authors = query.Select(author => new GetAuthorDto
            {
                FullName = author.FullName,
                Id=author.Id
            }).ToList();
            return authors;
        }

        public Author Get(int id)
        {
          return  _context.Authors.Find(id);
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
        }

        public bool IsExistBookForThisAuthor(int id)
        {
           return _context.Books.Any(_=>_.AuthorId == id);
        }

        public bool IsExist(int authorId)
        {
            return _context.Authors.Any(_ => _.Id == authorId);
        }
    }
}
