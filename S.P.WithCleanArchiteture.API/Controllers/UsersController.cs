﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Application.Interfaces;
using S.P.WithCleanArchitecture.Application.Services.LoggerService;
using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchiteture.API.DTOs.User;
using S.P.WithCleanArchiteture.API.ViewModels.User;

namespace S.P.WithCleanArchiteture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IValidatorBase _validatorBase;
        private IViewModelValidator<UserLoginViewModel> _loginviewModelValidator;
        private IViewModelValidator<UserRegistrationViewModel> _registrationviewModelValidator;
        private IUserService _userService;
        private ILoggerService _loggerService;
        private IPrintService _printService;
        private IMapper _mapper;

        public UsersController(
            IPrintService printService,
            ILoggerService loggerService,
            IUserService userService,
            IMapper mapper, 
            IValidatorBase validatorBase,
            IViewModelValidator<UserRegistrationViewModel> registrationviewModelValidator,
            IViewModelValidator<UserLoginViewModel> loginviewModelValidator)
        {
            _printService = printService;
            _loggerService = loggerService;
            _validatorBase = validatorBase;
            _userService = userService;
            _mapper = mapper;
            _registrationviewModelValidator = registrationviewModelValidator;
            _loginviewModelValidator = loginviewModelValidator;
        }

        //CRUD

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationViewModel userRegistrationViewModel)
        {

            _validatorBase.Validate<UserRegistrationViewModel>(userRegistrationViewModel, null);
            _registrationviewModelValidator.ValidateViewModel(userRegistrationViewModel);



            var UserDTO = _mapper.Map<UserDTO>(userRegistrationViewModel);

            bool IsRegistered = await _userService.UserRegistrationAsync(UserDTO);

            if (IsRegistered)
            {
                await _loggerService.LogIntoFile(
                      new LogObject()
                      {
                          CreatedDate = DateTime.UtcNow,
                          Message = $"Sucses: User Created ({_printService.GetPrintInfo<UserDTO>(UserDTO)})",
                          ResponseBody = StatusCodes.Status200OK
                      });

                return Ok(UserDTO);
            }

            return BadRequest("User registration failed.");

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel userLoginViewModel)
        {

            _validatorBase.Validate<UserLoginViewModel>(userLoginViewModel, null);
            _loginviewModelValidator.ValidateViewModel(userLoginViewModel);


            var LoginUserDTO = await _userService.UserLoginAsync(userLoginViewModel.UserName, userLoginViewModel.Password);

            var UserProfile = _mapper.Map<UserProfileViewModel>(LoginUserDTO);

            await _loggerService.LogIntoFile(
                     new LogObject()
                     {
                         CreatedDate = DateTime.UtcNow,
                         Message = $"Sucsess: User Login ({_printService.GetPrintInfo<UserProfileViewModel>(UserProfile)})",
                         ResponseBody = StatusCodes.Status200OK
                     });

            return Ok(UserProfile);

        }
        [HttpGet("User/{Id}")]
        public async Task<IActionResult> GetUser([FromRoute] int Id)
        {
            if (Id <= 0)
                throw new InvalidDataFormatException("Id of User must be greather than 0");

            var UserDTO = await _userService.GetUserById(Id);

            var UserProfile = _mapper.Map<UserProfileViewModel>(UserDTO);

            await _loggerService.LogIntoFile(
                    new LogObject()
                    {
                        CreatedDate = DateTime.UtcNow,
                        Message = $"Sucsess: User ProfileWiew ({UserProfile.ToString()})",
                        ResponseBody = StatusCodes.Status200OK
                    });

            return Ok(UserProfile);

        }

        [HttpDelete("User/{Id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int Id)
        {
            if (Id <= 0)
                throw new InvalidDataFormatException("Id of User must be greather than 0");

            await _userService.DeleteUserById(Id);

            return Ok($"Entity By Id {Id} is Deleted");

        }
    }
}
