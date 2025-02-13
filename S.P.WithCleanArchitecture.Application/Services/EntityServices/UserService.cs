using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Application.Interfaces;
using S.P.WithCleanArchitecture.Domain.Entities;
using S.P.WithCleanArchitecture.Domain.Enums;
using S.P.WithCleanArchitecture.Domain.Interfaces;
using S.P.WithCleanArchitecture.Domain.Exceptions.UserExceptions;
using S.P.WithCleanArchitecture.Infrastructure.Utils.PasswordHelper;
using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;
using AutoMapper;

namespace S.P.WithCleanArchitecture.Application.Services.EntityServices
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;    
        private IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<bool> UserRegistrationAsync(UserDTO userDTO)
        {

            DefineDefaultMoneyForRegisteredUser(userDTO);

            var User = _mapper.Map<User>(userDTO);



            await _userRepository.CreateEntity(User);

            return true;

        }
        public async Task<UserDTO> UserLoginAsync(string UserName, string password)
        {
            var User = await _userRepository.GetUserByUserName(UserName);

            if (User == null)
                throw new UserNotFoundException(new string[] { UserName, password });

            if (PasswordHasher.VerifyPassword(password, User.PasswordHash))
            {
                var UserDTO = _mapper.Map<UserDTO>(User);

                return UserDTO;
            }

            throw new UserNotFoundException(new string[] { UserName, password });
        }



        public async Task<UserDTO> GetUserById(int UserId)
        {
            var User = await _userRepository.GetEntityById(UserId);
            if (User == null)
                throw new UserNotFoundException($"User By Id {UserId} isn't found");

            return _mapper.Map<UserDTO>(User);
        }

        public async Task DeleteUserById(int UserId)
        {
            if (await _userRepository.DeleteEntityById(UserId) == false)
                throw new UserNotFoundException($"User By Id {UserId} isn't found");

        }

        public async Task DeleteUserByUserName(string UserName)
        {
            var User = await _userRepository.GetUserByUserName(UserName);

            if (User == null)
                throw new UserNotFoundException($"User By UserName {UserName} isn't found");

        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var User = _mapper.Map<User>(userDTO);

            await _userRepository.UpdateEntity(User);
        }


        //Priavate Methods
        private void DefineDefaultMoneyForRegisteredUser(UserDTO userDTO)
        {
            userDTO.Money = new MoneyDTO(100.00m, Currency.USD);
        }
    }
}
