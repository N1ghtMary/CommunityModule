using DTO.GroupDTO;

namespace Repository.GroupRepository;

public interface IGroupRepository
{
    GroupDTO Get(int Id);
    List<GroupDTO> GetAll();
    void Insert(CreateGroupDTO dto);
    void Update(UpdateGroupDTO dto);
    void Delete(int Id);
    void SaveChanges();
}