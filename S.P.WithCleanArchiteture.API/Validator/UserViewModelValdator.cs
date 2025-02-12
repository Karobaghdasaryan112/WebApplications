using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchiteture.API.DTOs.User;

namespace S.P.WithCleanArchiteture.API.Validator
{
    public class UserViewModelValidator : IViewModelValidator<UserLoginViewModel>
    {
        private const int _minimumLengthOfInput = 5;
        private const int _maximumLengthOfInput = 20;

        public void ValidateViewModel(UserLoginViewModel model)
        {
          
            var invalidMessages = new List<string>();

            // Validate UserName and Password length
            ValidateDatas(model.UserName, "UserName", invalidMessages);
            ValidateDatas(model.Password, "Password", invalidMessages);

            if (invalidMessages.Any())
                throw new InvalidDataFormatException(invalidMessages.ToArray());

        }

        private void ValidateDatas(string data, string propertyName, List<string> invalidMessages)
        {
            if (string.IsNullOrEmpty(data))
            {
                invalidMessages.Add($"{propertyName} cannot be empty.");
            }
            else
            {
                if (data.Length < _minimumLengthOfInput)
                    invalidMessages.Add($"{propertyName} is too short (minimum {_minimumLengthOfInput} characters).");

                if (data.Length > _maximumLengthOfInput)
                    invalidMessages.Add($"{propertyName} is too long (maximum {_maximumLengthOfInput} characters).");
            }
        }
    }
}
