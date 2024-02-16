using Library.Entities;
using Library.Services.Users.Contracts;
using Library.Services.Users.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts;

namespace Library.Services.Users
{
    public class UserAppService : UserService
    {

        private readonly UserRepository _userRepository;
        private readonly UnitOfWork _unitOfWork;
        public UserAppService(UserRepository userRepository, UnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(AddUserDto dto)
        {
            var user = new User();
            if (_userRepository.IsExist(dto.Name))
            {
                throw new Exception("name should be unique");
            }
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.CreateAt = DateTime.UtcNow;
            _userRepository.Add(user);
            await _unitOfWork.Complete();
        }
        public async Task Update(int id, UpdateUserDto dto)
        {

            if (!_userRepository.IsExist(id))
            {
                throw new Exception("user not found");
            }
            var user = _userRepository.Find(id);
            user.Name = dto.Name;
            user.Email = dto.Email;
            _userRepository.Update(user);
            await _unitOfWork.Complete();
        }
        public async Task Delete(int id)
        {
            if (!_userRepository.IsExist(id))
            {
                throw new Exception("user not found");
            }
            var user = _userRepository.Find(id);
            var IsRentUser = _userRepository.IsExistRentbookForThisUser(id);
            if (IsRentUser == true)
            {
                _userRepository.DeleteUserRentBooks(id);

            }

            _userRepository.Delete(user);
            _unitOfWork.Complete();
        }
        public List<GetUserDto> GetUser(GetUserFilterDto filterDto)
        {
            return _userRepository.GetUsersByName(filterDto);

        }
        public List<GetUserRentBookDto> GetUserRentBooks(int userId)
        {
            return _userRepository.GetUserRentBooksByID(userId);
        }


        public async Task AddUserRentBook(UserAddRentBookDto dto)
        {

            if (!_userRepository.IsExist(dto.UserName))
            {
                throw new Exception("user not found");
            }
            var user = _userRepository.Find(dto.UserName);
            if (!_userRepository.IsBookExists(dto.BookId))
            {
                throw new Exception("book not found");
            }
            var book = _userRepository.FindBook(dto.BookId);
            var bookRentCount = _userRepository.UserRentBookCount(user.Id);
            if (bookRentCount == 4)
            {
                throw new Exception("this user cant have more than 4 book to rent");
            }
            if (book.Stock <= 0)
            {
                throw new Exception("we are out of stock choose anothor book");

            }
            var userRentBook = new UserRentBook
            {
                IsBack = false,
                UserId = user.Id,
                BookId = book.Id,

            };

            book.Stock--;
            _userRepository.AddUserRentBooks(user, userRentBook);
            await _unitOfWork.Complete();
        }
        public async Task UpdateUserRentBook(UpdateUserRentBookDto dto)
        {
            var userRentBook = _userRepository.FindUserRentBook(dto.UserId, dto.BookId);
            if (userRentBook is null)
            {
                throw new Exception("wrong info!!!");
            }
            userRentBook.IsBack = true;
            var book = _userRepository.FindBook(dto.BookId);
            book.Stock++;
            await _unitOfWork.Complete();
        }
    }
}

