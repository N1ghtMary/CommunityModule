using Data;
using DTO.SubscriptionAuthorDTO;

namespace Repository.SubscriptionAuthorRepository;

public interface ISubscriptionAuthorRepository
{
    List<SubscriptionAuthorDTO> GetAll();
    List<SubscriptionAuthorDTO> GetUsers(int id);
    List<SubscriptionAuthorDTO> GetAuthors(int id);
    void ToggleActive(ToggleSubscriptionAuthorDTO dto);
    void SaveChanges();
}