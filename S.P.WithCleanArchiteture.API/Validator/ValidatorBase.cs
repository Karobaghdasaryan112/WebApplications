using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;

namespace S.P.WithCleanArchiteture.API.Validator
{
    public class ValidatorBase : IValidatorBase
    {

        public void Validate<TVIewModel>(TVIewModel model) where TVIewModel : class
        {
            if (model == null)
                throw new NullViewModelException(nameof(model));

            var properties = typeof(TVIewModel).GetProperties();
            var fields = typeof(TVIewModel).GetFields();

            var invalidProperties = properties
                .Where(property =>
                {
                    var value = property.GetValue(model);
                    return value == null || (value is string stringValue && string.IsNullOrEmpty(stringValue));
                })
                .Select(property => property.Name)
                .ToArray();

            var invalidFields = fields
                .Where(field =>
                {
                    var value = field.GetValue(model);
                    return value == null || (value is string stringValue && string.IsNullOrEmpty(stringValue));
                })
                .Select(property => property.Name)
                .ToArray();

            if (invalidProperties.Any())
                throw new InvalidDataFormatException(invalidProperties);

            if (invalidFields.Any())
                throw new InvalidDataFormatException(invalidFields);
        }
    }
}
