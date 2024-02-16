using Library.Entities;
using Library.Services.Authors.Contracts;
using Library.Services.Authors.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts;

namespace Library.Services.Authors
{
    public class AuthorAppService : AuthorService
    {
        private readonly AuthorRepository _authorRepository;
        private readonly UnitOfWork _unitOfWork;
        public AuthorAppService(AuthorRepository authorRepository, UnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(AddAuthorDto dto)
        {
            var author = new Author();
            author.FullName = dto.FullName;
            _authorRepository.Add(author);
            await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {

            if (!_authorRepository.IsExist(id))
            {
                throw new Exception("author not found");
            }
            var author = _authorRepository.Get(id);
            if (_authorRepository.IsExistBookForThisAuthor(id))
            {
                throw new Exception("First change books with this author then remove it");
            }
            _authorRepository.Delete(author);
            await _unitOfWork.Complete();
        }

        public List<GetAuthorDto> GetAll(GetAuthorFilterDto dto)
        {
            return _authorRepository.GetAll(dto);
        }

        public async Task Update(int id, UpdateAuthorDto dto)
        {
            if (!_authorRepository.IsExist(id))
            {
                throw new Exception("author not found");
            }
            var author = _authorRepository.Get(id);
            author.FullName = dto.FullName;
            _authorRepository.Update(author);
            await _unitOfWork.Complete();
        }
    }
}
