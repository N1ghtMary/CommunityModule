using Data;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Services.UserService;

public interface IUserService
{
    Task<UserDTO> GetUser(string id);
    Task<List<User>> GetUsers();
    Task<IdentityResult> InsertUser(CreateUserDTO dto);
    Task<IActionResult> UpdateUser(UpdateUserDTO dto);
    Task<IActionResult> ChangePassword(ChangePasswordUserDTO dto);
    void DeleteUser(string id);
}