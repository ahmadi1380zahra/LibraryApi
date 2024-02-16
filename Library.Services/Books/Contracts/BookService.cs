using Library.Services.Books.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contracts
{
    public interface BookService
    {
        Task Add(AddBookDto dto);
        Task Update(int id, UpdateBookDto dto);
        Task Delete(int id);
        List<GetBookDto> GetAll(GetBookFilterDto filterDto);
    }
}
