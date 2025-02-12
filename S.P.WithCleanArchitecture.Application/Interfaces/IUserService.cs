using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;

namespace S.P.WithCleanArchitecture.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> UserRegistrationAsync(UserDTO userDTO);
    }

}
