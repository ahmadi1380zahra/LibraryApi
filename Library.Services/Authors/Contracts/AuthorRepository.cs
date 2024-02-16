using Library.Entities;
using Library.Services.Authors.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Authors.Contracts
{
    public interface AuthorRepository
    {
        void Add(Author author);
        Author Get(int id);
        void Delete(Author author);
        void Update(Author author);
        List<GetAuthorDto> GetAll(GetAuthorFilterDto dto);
        bool IsExistBookForThisAuthor(int id);
        bool IsExist(int authorId);
    }
}
