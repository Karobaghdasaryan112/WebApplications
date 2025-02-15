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
        private bool _isTheSameForUpdate = false;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<bool> UserRegistrationAsync(UserDTO userDTO)
        {

            DefineDefaultMoneyForRegisteredUser(userDTO);

            var User = _mapper.Map<User>(userDTO);

            User.CreatedDate = DateTime.Now;
            User.UpdatedAt = DateTime.Now;

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

        public async Task UpdateUser(UserDTO userDTO, UserDTO updateUserDTO,int Id,string oldPassword)
        {
            if (!PasswordHasher.VerifyPassword(oldPassword, userDTO.PasswordHash))
                throw new UserUpdateException("OldPassword is Invalid for Update");

            if (IsTheSameForUpdate(userDTO, updateUserDTO))
            {
                updateUserDTO.Money = userDTO.Money;

                var User = _mapper.Map<User>(updateUserDTO);


                User.UpdatedAt = DateTime.Now;

                await _userRepository.UpdateEntity(User,Id);

                return;
            }
            throw new UserUpdateException("User Update Is fail.please change any datas!");
        }


        //Priavate Methods
        private void DefineDefaultMoneyForRegisteredUser(UserDTO userDTO)
        {
            userDTO.Money = new MoneyDTO(100.00m, Currency.USD);
        }

        private bool IsTheSameForUpdate<TValue1, TValue2>(TValue1 userDTO, TValue2 updateUserDTO)
        {
            var Value1Properties = typeof(TValue1).GetProperties();

            var Value2Properties = typeof(TValue2).GetProperties();

            var Value1Fields = typeof(TValue1).GetFields();

            var Value2Fields = typeof(TValue2).GetFields();

            for (var i = 0; i < Value1Properties.Length; i++)
            {
                if (Value1Properties[i].GetValue(userDTO) != default && Value2Properties[i].GetValue(updateUserDTO) != default)
                {
                    if (Value1Properties[i].PropertyType.IsClass)
                    {
                        var Value1PropertyValue = Value1Properties[i].GetValue(userDTO);
                        var Value2PropertyValue = Value2Properties[i].GetValue(updateUserDTO);

                        _isTheSameForUpdate = IsTheSameForUpdate(Value1PropertyValue, Value2PropertyValue);
                        if (!_isTheSameForUpdate)
                            return true;
                    }
                    _isTheSameForUpdate = Value1Properties[i].GetValue(userDTO) == Value2Properties[i].GetValue(updateUserDTO);
                    if (!_isTheSameForUpdate)
                        return true;
                }
            }

            for (var i = 0; i < Value2Fields.Length; i++)
            {
                if (Value1Fields[i].GetValue(userDTO) != default && Value2Fields[i].GetValue(updateUserDTO) != default)
                {
                    if (Value1Fields[i].FieldType.IsClass)
                    {
                        var Value1FieldValue = Value1Fields[i].GetValue(userDTO);
                        var Value2FieldValue = Value2Fields[i].GetValue(updateUserDTO);

                        _isTheSameForUpdate = IsTheSameForUpdate(Value1FieldValue, Value2FieldValue);
                        if (!_isTheSameForUpdate)
                            return true;
                    }
                    _isTheSameForUpdate = Value1Properties[i].GetValue(userDTO) == Value2Properties[i].GetValue(updateUserDTO);
                    if (!_isTheSameForUpdate)
                        return true;
                }
            }


            return _isTheSameForUpdate;
        }
    }
}
