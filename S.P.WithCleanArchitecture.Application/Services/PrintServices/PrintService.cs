using S.P.WithCleanArchitecture.Application.Interfaces;

namespace S.P.WithCleanArchitecture.Application.Services.PrintServices
{
    public class PrintService : IPrintService
    {
        public string GetPrintInfo<TPrint>(TPrint print, HashSet<object> visited = null)
        {

            if (print == null)
                return "Empty Datas";

            List<string> _printResult = new List<string>();

            visited = visited ?? new HashSet<object>();

            if (!visited.Add(print))
                return string.Join(",", _printResult.ToArray());

            var Properties = print.GetType().GetProperties();

            var fields = print.GetType().GetFields();

            foreach (var field in fields)
            {
                string printResultItem = default;

                var ValueOfField = field.GetValue(print);
                var NameOfField = field.Name;

                if (field.FieldType.IsClass && ValueOfField != null && field.FieldType != typeof(string))
                {
                    printResultItem = $"[{ValueOfField.GetType().Name}:[{GetPrintInfo<object>(ValueOfField,visited) }]]";
                }
                else if (!field.FieldType.IsClass || field.FieldType == typeof(string) && ValueOfField != null)
                {
                    printResultItem = $" {NameOfField}:{ValueOfField}, ";
                }
                if (printResultItem != null)
                    _printResult.Add(printResultItem);

            }

            foreach (var property in Properties)
            {
                string printResultItem = default;

                var ValueOfProperty = property.GetValue(print);
                var NameOfField = property.Name;


                if (property.PropertyType.IsClass && ValueOfProperty != null && property.PropertyType != typeof(string))
                {
                    printResultItem = $"[{ValueOfProperty.GetType().Name}:[{GetPrintInfo<object>(ValueOfProperty,visited)}]]";
                }
                else if (property.PropertyType == typeof(string) || !property.PropertyType.IsClass && ValueOfProperty != null)
                {
                    printResultItem = $" {NameOfField}:{ValueOfProperty}, ";
                }

                if (printResultItem != null)
                    _printResult.Add(printResultItem);
            }

            return _printResult.Any() ? string.Join(",",  _printResult.ToArray()) : "Empty Data";
        }
    }
}
