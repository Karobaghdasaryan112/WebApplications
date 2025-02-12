using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchiteture.API.DTOs.User;
using System.Text.RegularExpressions;

namespace S.P.WithCleanArchiteture.API.Validator.UserViewModelValidators
{
    public class UserRegistrationViewModelValidator : IViewModelValidator<UserRegistrationViewModel>
    {
        private const int MINIMUM_LENGTH_OF_USERNAME_AND_PASSWORD = 5;
        private const int MAXIMUM_LENGTH_OF_USERNAME_AND_PASSWORD = 20;
        private const int MINIMUM_AGE = 1;
        private const int MAXIMUM_AGE = 100;
        private const int CITY_MINIMUM_LENGTH = 3;
        private const int CITY_MAXIMUM_LENGTH = 15;
        private const int COUNTRY_MINIMUM_LENGTH = 3;
        private const int COUNTRY_MAXIMUM_LENGTH = 15;
        private const int STREET_MINIMUM_LENGTH = 3;
        private const int STREET_MAXIMUM_LENGTH = 15;
        private const int POSTAL_CODE_LENGTH = 4;

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

        private void ValidateString(string data, List<string> messages, int minLength, int maxLength, string fieldName)
        {
            if (string.IsNullOrEmpty(data))
            {
                messages.Add($"{fieldName} cannot be empty.");
                return;
            }

            int length = data.Length;

            if (length < minLength)
                messages.Add($"{fieldName} is too short (minimum {minLength} characters).");

            if (length > maxLength)
                messages.Add($"{fieldName} is too long (maximum {maxLength} characters).");
        }

        private void ValidateNumber(int data, List<string> messages, int min, int max, string fieldName)
        {
            if (data < min)
                messages.Add($"{fieldName} cannot be less than {min}.");

            if (data > max)
                messages.Add($"{fieldName} cannot be greater than {max}.");
        }

        private void ValidateExactLength(string data, List<string> messages, int exactLength, string fieldName)
        {
            if (string.IsNullOrEmpty(data))
            {
                messages.Add($"{fieldName} cannot be empty.");
                return;
            }

            if (data.Length != exactLength)
                messages.Add($"{fieldName} must be exactly {exactLength} characters.");
        }

        private void ValidateEmail(string data, List<string> messages)
        {
            if (string.IsNullOrEmpty(data))
            {
                messages.Add("Email cannot be empty.");
                return;
            }

            if (!Regex.IsMatch(data, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                messages.Add("Email format is invalid.");
            }
        }

    }
}
