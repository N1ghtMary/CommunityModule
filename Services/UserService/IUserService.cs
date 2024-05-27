using Data;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;

namespace Services.UserService;

public interface IUserService
{
    Task<UserDTO> GetUser(string id);
    Task<List<User>> GetUsers();
    Task<IdentityResult> InsertUser(CreateUserDTO dto);
    void UpdateUser(UpdateUserDTO dto);
    void DeleteUser(string id);
}