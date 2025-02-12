using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Application.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchiteture.API.DTOs.User;

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
        private IMapper _mapper;

        public UsersController(
            IUserService userService,
            IMapper mapper, 
            IValidatorBase validatorBase,
            IViewModelValidator<UserRegistrationViewModel> registrationviewModelValidator,
            IViewModelValidator<UserLoginViewModel> loginviewModelValidator)
        {
            _validatorBase = validatorBase;
            _userService = userService;
            _mapper = mapper;
            _registrationviewModelValidator = registrationviewModelValidator;
            _loginviewModelValidator = loginviewModelValidator;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationViewModel userRegistrationViewModel)
        {

            _validatorBase.Validate<UserRegistrationViewModel>(userRegistrationViewModel);
            _registrationviewModelValidator.ValidateViewModel(userRegistrationViewModel);

            var UserDTO = _mapper.Map<UserDTO>(userRegistrationViewModel);

            bool IsRegistered = await _userService.UserRegistrationAsync(UserDTO);

            if (IsRegistered)
                return Ok(UserDTO);

            return BadRequest("User registration failed.");

        }
    }
}
