using Data;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Repository.UserRepository;

public interface IUserRepository
{
    //UserDTO Get(string id);
    Task<UserDTO> Get(string id);
    Task<List<User>> GetAll();
    Task<IdentityResult> Insert(CreateUserDTO dto);
    Task<IActionResult> Update(UpdateUserDTO dto);
    Task<IActionResult> ChangePassword(ChangePasswordUserDTO dto);
    void Delete(string id);
    void SaveChanges();
}