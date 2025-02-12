using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchiteture.API.DTOs.User;

namespace S.P.WithCleanArchiteture.API.Validator.UserViewModelValidators
{
    public class UserViewModelValidator : IViewModelValidator<UserLoginViewModel>
    {
        private const int _minimumLengthOfInput = 5;
        private const int _maximumLengthOfInput = 20;

        public void ValidateViewModel(UserLoginViewModel model)
        {

            var invalidMessages = new List<string>();

            ValidateLoginInputs(model.UserName, invalidMessages);
            ValidateLoginInputs(model.Password, invalidMessages);

            if (invalidMessages.Any())
                throw new InvalidDataFormatException(string.Join(Environment.NewLine, invalidMessages));

        }

        private void ValidateLoginInputs(string data, List<string> invalidMessages)
        {

            if (data.Length < _minimumLengthOfInput)
                invalidMessages.Add($"{nameof(data)} is too short (minimum {_minimumLengthOfInput} characters).");

            if (data.Length > _maximumLengthOfInput)
                invalidMessages.Add($"{nameof(data)} is too long (maximum {_maximumLengthOfInput} characters).");
        }
    }
}
