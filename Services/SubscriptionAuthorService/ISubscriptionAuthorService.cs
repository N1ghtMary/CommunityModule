using DTO.SubscriptionAuthorDTO;

namespace Services.SubscriptionAuthorService;

public interface ISubscriptionAuthorService
{
    List<SubscriptionAuthorDTO> GetSubscriptions();
    List<SubscriptionAuthorDTO> GetUserSubscriptions(int id);
    List<SubscriptionAuthorDTO> GetAuthorSubscriptions(int id);
    void ToggleActiveSubscriptions(ToggleSubscriptionAuthorDTO dto);
}