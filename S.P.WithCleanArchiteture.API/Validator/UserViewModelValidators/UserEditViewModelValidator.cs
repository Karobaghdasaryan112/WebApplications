using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchiteture.API.DTOs.User;
using S.P.WithCleanArchiteture.API.ViewModels.User;

namespace S.P.WithCleanArchiteture.API.Validator.UserViewModelValidators
{
    public class UserEditViewModelValidator : InputsValidatorBase, IViewModelValidator<UserEditViewModel>
    {

        private int _propertiesAndFieldsCount;

        public void ValidateViewModel(UserEditViewModel model)
        {
            List<string> invalidMessages = new List<string>();

            ValidateNumber(model.Age, invalidMessages, MINIMUM_AGE, MAXIMUM_AGE, nameof(model.Age));

            ValidateString(model.NewPassword, invalidMessages, MINIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, MAXIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, nameof(model.NewPassword));

            ValidateString(model.UserName, invalidMessages, MINIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, MAXIMUM_LENGTH_OF_USERNAME_AND_PASSWORD, nameof(model.UserName));

            ValidateString(model.Address?.Country, invalidMessages, COUNTRY_MINIMUM_LENGTH, COUNTRY_MAXIMUM_LENGTH, nameof(model.Address.Country));

            ValidateString(model.Address?.City, invalidMessages, CITY_MINIMUM_LENGTH, CITY_MAXIMUM_LENGTH, nameof(model.Address.City));

            ValidateExactLength(model.Address?.PostalCode, invalidMessages, POSTAL_CODE_LENGTH, nameof(model.Address.PostalCode));

            ValidateEmail(model.Email, invalidMessages);

            GetAllPrpertiesOrFieldsCount(model);

            if (invalidMessages.Count == _propertiesAndFieldsCount)
                throw new InvalidDataFormatException(string.Join(Environment.NewLine, invalidMessages));

        }

        private int GetAllPrpertiesOrFieldsCount<TValue>(TValue model)
        {
            if (model == null)
                return 0;


            var properties = model.GetType().GetProperties();
            var fields = model.GetType().GetFields();

            _propertiesAndFieldsCount = properties.Length + fields.Length;


            foreach (var property in properties)
            {
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    var propertyValue = property.GetValue(model);
                    _propertiesAndFieldsCount += GetAllPrpertiesOrFieldsCount(propertyValue);  
                }
            }

            foreach (var field in fields)
            {
                if (field.FieldType.IsClass && field.FieldType != typeof(string))
                {
                    var propertyValue = field.GetValue(model);
                    _propertiesAndFieldsCount += GetAllPrpertiesOrFieldsCount(propertyValue);
                }
            }



            return _propertiesAndFieldsCount;
        }
    }   
}

