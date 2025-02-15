using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchiteture.API.DTOs.User;
using System.Text.RegularExpressions;

namespace S.P.WithCleanArchiteture.API.Validator
{
    public class InputsValidatorBase : IInputValidatorBase
    {
        protected const int MINIMUM_LENGTH_OF_USERNAME_AND_PASSWORD = 5;
        protected const int MAXIMUM_LENGTH_OF_USERNAME_AND_PASSWORD = 20;
        protected const int MINIMUM_AGE = 1;
        protected const int MAXIMUM_AGE = 100;
        protected const int CITY_MINIMUM_LENGTH = 3;
        protected const int CITY_MAXIMUM_LENGTH = 15;
        protected const int COUNTRY_MINIMUM_LENGTH = 3;
        protected const int COUNTRY_MAXIMUM_LENGTH = 15;
        protected const int STREET_MINIMUM_LENGTH = 3;
        protected const int STREET_MAXIMUM_LENGTH = 15;
        protected const int POSTAL_CODE_LENGTH = 4;
       


        public void ValidateString(string data, List<string> messages, int minLength, int maxLength, string fieldName)
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

        public void ValidateNumber(int data, List<string> messages, int min, int max, string fieldName)
        {
            if (data < min)
                messages.Add($"{fieldName} cannot be less than {min}.");

            if (data > max)
                messages.Add($"{fieldName} cannot be greater than {max}.");
        }

        public void ValidateExactLength(string data, List<string> messages, int exactLength, string fieldName)
        {
            if (string.IsNullOrEmpty(data))
            {
                messages.Add($"{fieldName} cannot be empty.");
                return;
            }

            if (data.Length != exactLength)
                messages.Add($"{fieldName} must be exactly {exactLength} characters.");
        }

        public void ValidateEmail(string data, List<string> messages)
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
