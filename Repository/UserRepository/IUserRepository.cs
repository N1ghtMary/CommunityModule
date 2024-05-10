using DTO.UserDTO;

namespace Repository.UserRepository;

public interface IUserRepository
{
    UserDTO Get(int Id);
    List<UserDTO> GetAll();
    void Insert(CreateUserDTO dto);
    void Update(UpdateUserDTO dto);
    void Delete(int Id);
    void SaveChanges();
}