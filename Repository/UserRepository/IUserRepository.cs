using Data;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;

namespace Repository.UserRepository;

public interface IUserRepository
{
    //UserDTO Get(string id);
    Task<UserDTO> Get(string id);
    Task<List<User>> GetAll();
    Task<IdentityResult> Insert(CreateUserDTO dto);
    void Update(UpdateUserDTO dto);
    void Delete(string id);
    void SaveChanges();
}