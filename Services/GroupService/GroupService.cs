using DTO.GroupDTO;
using Repository.GroupRepository;

namespace Services.GroupService;

public class GroupService(IGroupRepository groupRepository) : IGroupService
{
    private IGroupRepository _groupRepository = groupRepository;

    public GroupDTO GetGroup(int Id)
    {
        return _groupRepository.Get(Id);
    }

    public List<GroupDTO> GetGroups()
    {
        return _groupRepository.GetAll();
    }

    public void InsertGroup(CreateGroupDTO dto)
    {
        _groupRepository.Insert(dto);
    }

    public void UpdateGroup(UpdateGroupDTO dto)
    {
        _groupRepository.Update(dto);
    }

    public void DeleteGroup(int Id)
    {
        _groupRepository.Delete(Id);
    }
}