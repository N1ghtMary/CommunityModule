using DTO.GroupDTO;

namespace Services.GroupService;

public interface IGroupService
{
    GroupDTO GetGroup(int Id);
    List<GroupDTO> GetGroups();
    void InsertGroup(CreateGroupDTO dto);
    void UpdateGroup(UpdateGroupDTO dto);
    void DeleteGroup(int Id);
}