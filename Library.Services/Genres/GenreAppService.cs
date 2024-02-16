using Library.Entities;
using Library.Services.Genres.Contracts;
using Library.Services.Genres.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts;

namespace Library.Services.Genres
{
    public class GenreAppService : GenreService
    {
        private readonly GenreRepository _genreRepository;
        private readonly UnitOfWork _unitOfWork;
        public GenreAppService(GenreRepository genreRepository,
                               UnitOfWork unitOfWork)
        {
            _genreRepository = genreRepository;     
            _unitOfWork = unitOfWork;
        }
        public async Task Add(AddGenreDto dto)
        {
            var genre = new Genre();
            genre.Title = dto.Title;
            _genreRepository.Add(genre);
           await  _unitOfWork.Complete();
         
        }

        public async Task Delete(int id)
        {
           if (!_genreRepository.IsExist(id))
            {
                throw new Exception("Genre not existed");
            }
            if (_genreRepository.IsExistBookForThisGenre (id))
            {
                throw new Exception("First change books in this genre then delete this genre");
            }
            var genre = _genreRepository.Get(id);
            _genreRepository.Delete(genre);
           await _unitOfWork.Complete();
           
        }

        public List<GetGenreDto> GetAll(GetGenreDtoFilter dto)
        {
         return  _genreRepository.GetAll(dto);
        }

        public async Task Update(int id, UpdateGenreDto dto)
        {
            var genre = _genreRepository.Get(id);
            if (genre is null)
            {
                throw new Exception("Genre not existed");
            }
            genre.Title = dto.Title;
            _genreRepository.Update(genre);
          await  _unitOfWork.Complete();
            
        }
    }
}
