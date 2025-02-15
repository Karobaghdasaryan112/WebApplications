
namespace S.P.WithCleanArchitecture.Application.Validations.Interfaces
{
    public interface IInputValidatorBase
    {
        void ValidateString(string data, List<string> messages, int minLength, int maxLength, string fieldName);

        void ValidateNumber(int data, List<string> messages, int min, int max, string fieldName);

        void ValidateExactLength(string data, List<string> messages, int exactLength, string fieldName);

        void ValidateEmail(string data, List<string> messages);
    }
}
