using DTO.SubscriptionAuthorDTO;
using Microsoft.AspNetCore.Mvc;

namespace Services.SubscriptionAuthorService;

public interface ISubscriptionAuthorService
{
    List<SubscriptionAuthorDTO> GetSubscriptions();
    List<SubscriptionAuthorDTO> GetUserSubscriptions(string id);
    List<SubscriptionAuthorDTO> GetAuthorSubscriptions(string id);
    Task<IActionResult> ToggleActiveSubscriptions(ToggleSubscriptionAuthorDTO dto);
}