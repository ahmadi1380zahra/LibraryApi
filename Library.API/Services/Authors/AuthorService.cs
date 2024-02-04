using Library.API.Models;
using Library.API.Services.Authors.AuthorDto;

namespace Library.API.Services.Authors
{
    public class AuthorService
    {
        EFDataContext _context=new EFDataContext();
        public void AddAuthor(AddAuthorDto dto)
        {
            var author=new Author();
            author.FullName=dto.FullName;
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        public void UpdateAuthor(int id,UpdateAuthorDto dto)
        {
            var author=_context.Authors.Find(id);
            if(author == null)
            {
                throw new Exception("author not found");
            }
            author.FullName=dto.FullName;
            _context.SaveChanges();

        }
        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                throw new Exception("author not found");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
        public List<GetAuthorDto> GetAuthor(GetAuthorFilterDto dto)
        {
            IQueryable<Author>  query = _context.Authors;
            if (!string.IsNullOrWhiteSpace(dto.FullName))
            {
                query = query.Where(_ => _.FullName.Contains(dto.FullName));
            }
            List<GetAuthorDto> authors = query.Select(author => new GetAuthorDto
            {
                FullName = author.FullName
            }).ToList();
            return authors;
        }
    }
}
