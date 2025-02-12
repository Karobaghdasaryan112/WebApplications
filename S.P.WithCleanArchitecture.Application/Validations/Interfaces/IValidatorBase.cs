

namespace S.P.WithCleanArchitecture.Application.Validations.Interfaces
{
    public interface IValidatorBase 
    {
        void Validate<TVIewModel>(TVIewModel model, HashSet<object>? visited) where TVIewModel : class;
    }
}
