using DTO.SubscriptionAuthorDTO;
using Repository.SubscriptionAuthorRepository;

namespace Services.SubscriptionAuthorService;

public class SubscriptionAuthorService(ISubscriptionAuthorRepository subscriptionAuthorRepository):ISubscriptionAuthorService
{
    private ISubscriptionAuthorRepository _subscriptionAuthorRepository = subscriptionAuthorRepository;

    public List<SubscriptionAuthorDTO> GetSubscriptions()
    {
        return _subscriptionAuthorRepository.GetAll();
    }

    public List<SubscriptionAuthorDTO> GetUserSubscriptions(int id)
    {
        return _subscriptionAuthorRepository.GetUsers(id);
    }

    public List<SubscriptionAuthorDTO> GetAuthorSubscriptions(int id)
    {
        return _subscriptionAuthorRepository.GetAuthors(id);
    }

    public void ToggleActiveSubscriptions(ToggleSubscriptionAuthorDTO dto)
    {
        _subscriptionAuthorRepository.ToggleActive(dto);
    }
}