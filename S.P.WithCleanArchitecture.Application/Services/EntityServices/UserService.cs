using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Application.Interfaces;
using S.P.WithCleanArchitecture.Domain.Entities;
using S.P.WithCleanArchitecture.Domain.Enums;
using S.P.WithCleanArchitecture.Domain.Interfaces;
using S.P.WithCleanArchitecture.Domain.ValueObjects;
using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;

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


            var User = _mapper.Map<User>(userDTO);

            DefineDefaultMoneyForRegisteredUser(userDTO);

            await _userRepository.CreateEntity(User);

            return true;

        }

        private void DefineDefaultMoneyForRegisteredUser(UserDTO userDTO)
        {
            userDTO.Money = new MoneyDTO(100.00m, Currency.USD);
        }
    }
}
