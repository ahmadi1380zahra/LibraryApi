using Library.Services.Authors.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Authors.Contracts
{
    public interface AuthorService
    {
        Task Add(AddAuthorDto dto);
        Task Update(int id,UpdateAuthorDto dto);
        Task Delete(int id);
        List<GetAuthorDto> GetAll(GetAuthorFilterDto dto);
    }
}
