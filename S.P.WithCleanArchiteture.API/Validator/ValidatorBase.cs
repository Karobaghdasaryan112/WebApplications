using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;

namespace S.P.WithCleanArchiteture.API.Validator
{
    public class ValidatorBase : IValidatorBase
    {

        public void Validate<TViewModel>(TViewModel model, HashSet<object> visited = null) where TViewModel : class
        {
            if (model == null)
                throw new NullViewModelException(nameof(model));

            visited ??= new HashSet<object>();

            if (!visited.Add(model))
                return;

            var properties = typeof(TViewModel).GetProperties();
            var fields = typeof(TViewModel).GetFields();

            var invalidProperties = properties
                .Where(property =>
                {
                    if (!property.CanRead) return false;

                    var value = property.GetValue(model);
                    if (property.PropertyType.IsClass && property.PropertyType != typeof(string) && value != null)
                    {
                        Validate(value, visited);
                    }
                    return value == null || (value is string stringValue && string.IsNullOrEmpty(stringValue));
                })
                .Select(property => property.Name)
                .ToArray();

            var invalidFields = fields
                .Where(field =>
                {
                    var value = field.GetValue(model);
                    if (field.FieldType.IsClass && field.FieldType != typeof(string) && value != null)
                    {
                        Validate(value, visited);
                    }
                    return value == null || (value is string stringValue && string.IsNullOrEmpty(stringValue));
                })
                .Select(field => field.Name)
                .ToArray();

            if (invalidProperties.Any())
                throw new InvalidDataFormatException($"Invalid properties: {string.Join(", ", invalidProperties)}");

            if (invalidFields.Any())
                throw new InvalidDataFormatException($"Invalid fields: {string.Join(", ", invalidFields)}");
        }

    }
}
