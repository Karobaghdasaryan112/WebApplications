

using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchiteture.API.DTOs.User;

namespace S.P.WithCleanArchiteture.API.Validator
{
    public class UserRegistrationViewModelValidator : IViewModelValidator<UserRegistrationViewModel>
    {
        private const int _minimumLengthOfInput = 5;
        private const int _maximumLengthOfInput = 20;

        public void ValidateViewModel(UserRegistrationViewModel model)
        {
            throw new NotImplementedException();
        }


    }
}
