using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchiteture.API.DTOs.User;

namespace S.P.WithCleanArchiteture.API.Validator.UserViewModelValidators
{
    public class UserViewModelValidator : InputsValidatorBase, IViewModelValidator<UserLoginViewModel>
    {


        public void ValidateViewModel(UserLoginViewModel model)
        {
            var invalidMessages = new List<string>();

            ValidateString(model.UserName, invalidMessages, MINIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, MAXIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, nameof(model.UserName));
            ValidateString(model.Password, invalidMessages, MINIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, MAXIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, nameof(model.Password));

            if (invalidMessages.Any())
                throw new InvalidDataFormatException(string.Join(Environment.NewLine, invalidMessages));

        }
    }
}
