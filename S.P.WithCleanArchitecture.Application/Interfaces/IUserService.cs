using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;

namespace S.P.WithCleanArchitecture.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> UserRegistrationAsync(UserDTO userDTO);

        Task<UserDTO> UserLoginAsync(string UserName, string password);

        Task<UserDTO> GetUserById(int UserId);

        Task DeleteUserById(int UserId);
        
        Task DeleteUserByUserName(string UserName);

        Task UpdateUser(UserDTO userDTO,UserDTO updateUserDTO,int Id,string oldPassword);


    }

}
