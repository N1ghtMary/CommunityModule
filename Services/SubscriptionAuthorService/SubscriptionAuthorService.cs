using DTO.SubscriptionAuthorDTO;
using Microsoft.AspNetCore.Mvc;
using Repository.SubscriptionAuthorRepository;

namespace Services.SubscriptionAuthorService;

public class SubscriptionAuthorService(ISubscriptionAuthorRepository subscriptionAuthorRepository):ISubscriptionAuthorService
{
    private ISubscriptionAuthorRepository _subscriptionAuthorRepository = subscriptionAuthorRepository;

    public List<SubscriptionAuthorDTO> GetSubscriptions()
    {
        return _subscriptionAuthorRepository.GetAll();
    }

    public List<SubscriptionAuthorDTO> GetUserSubscriptions(string id)
    {
        return _subscriptionAuthorRepository.GetUsers(id);
    }

    public List<SubscriptionAuthorDTO> GetAuthorSubscriptions(string id)
    {
        return _subscriptionAuthorRepository.GetAuthors(id);
    }

    public async Task<IActionResult> ToggleActiveSubscriptions(ToggleSubscriptionAuthorDTO dto)
    {
        return await _subscriptionAuthorRepository.ToggleActive(dto);
    }
}