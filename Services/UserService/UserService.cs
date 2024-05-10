using DTO.UserDTO;
using Repository.UserRepository;

namespace Services.UserService;

public class UserService(IUserRepository userRepository) : IUserService
{
    private IUserRepository _userRepository = userRepository;

    public UserDTO GetUser(int Id)
    {
        return _userRepository.Get(Id);
    }

    public List<UserDTO> GetUsers()
    {
        return _userRepository.GetAll();
    }

    public void InsertUser(CreateUserDTO dto)
    {
        _userRepository.Insert(dto);
    }

    public void UpdateUser(UpdateUserDTO dto)
    {
        _userRepository.Update(dto);
    }

    public void DeleteUser(int Id)
    {
        _userRepository.Delete(Id);
    }
}