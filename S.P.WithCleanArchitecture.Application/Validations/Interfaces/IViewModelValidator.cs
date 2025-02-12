
namespace S.P.WithCleanArchitecture.Application.Validations.Interfaces
{
    public interface IViewModelValidator<TViewModel> where TViewModel : class
    {
        void ValidateViewModel(TViewModel model);
    }
}
