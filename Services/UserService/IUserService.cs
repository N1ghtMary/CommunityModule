using DTO.UserDTO;

namespace Services.UserService;

public interface IUserService
{
    UserDTO GetUser(int Id);
    List<UserDTO> GetUsers();
    void InsertUser(CreateUserDTO dto);
    void UpdateUser(UpdateUserDTO dto);
    void DeleteUser(int Id);
}