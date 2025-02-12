

namespace S.P.WithCleanArchitecture.Application.Validations.Interfaces
{
    public interface IValidatorBase 
    {
        void Validate<TVIewModel>(TVIewModel model) where TVIewModel : class;
    }
}
