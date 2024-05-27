using Data;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using Repository.UserRepository;

namespace Services.UserService;

public class UserService(IUserRepository userRepository) : IUserService
{
    private IUserRepository _userRepository = userRepository;

    public async Task<UserDTO> GetUser(string id)
    {
        return await _userRepository.Get(id);
    }

    public Task<List<User>> GetUsers()
    {
        return _userRepository.GetAll();
    }

    public async Task<IdentityResult> InsertUser(CreateUserDTO dto)
    {
        return await _userRepository.Insert(dto);
    }

    public void UpdateUser(UpdateUserDTO dto)
    {
        _userRepository.Update(dto);
    }

    public void DeleteUser(string id)
    {
        _userRepository.Delete(id);
    }
}