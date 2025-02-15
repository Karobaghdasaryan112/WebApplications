using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchiteture.API.DTOs.User;
using System.Text.RegularExpressions;

namespace S.P.WithCleanArchiteture.API.Validator.UserViewModelValidators
{
    public class UserRegistrationViewModelValidator :InputsValidatorBase, IViewModelValidator<UserRegistrationViewModel>
    {
        public void ValidateViewModel(UserRegistrationViewModel model)
        {
            List<string> invalidMessages = new List<string>();

            ValidateNumber(model.Age, invalidMessages, MINIMUM_AGE, MAXIMUM_AGE, nameof(model.Age));

            ValidateString(model.Password, invalidMessages, MINIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, MAXIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, nameof(model.Password));

            ValidateString(model.UserName, invalidMessages, MINIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, MAXIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, nameof(model.UserName));

            ValidateString(model.Address?.Country, invalidMessages, COUNTRY_MINIMUM_LENGTH, COUNTRY_MAXIMUM_LENGTH, nameof(model.Address.Country));

            ValidateString(model.Address?.City, invalidMessages, CITY_MINIMUM_LENGTH, CITY_MAXIMUM_LENGTH, nameof(model.Address.City));

            ValidateExactLength(model.Address?.PostalCode, invalidMessages, POSTAL_CODE_LENGTH, nameof(model.Address.PostalCode));

            ValidateEmail(model.Email, invalidMessages);

            if (invalidMessages.Any())
                throw new InvalidDataFormatException(string.Join(Environment.NewLine, invalidMessages));
        }
    }
}
