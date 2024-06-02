using DTO.SubscriptionAuthorDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.SubscriptionAuthorService;

namespace CommunityModule.Controllers;

[Authorize]
[ApiController]
[Route("subscriptionauthor")]
public class SubscriptionAuthorController(ISubscriptionAuthorService subscriptionAuthorService):Controller
{
    [HttpGet]
    public JsonResult GetSubscriptions()
    {
        var subscriptions = subscriptionAuthorService.GetSubscriptions();
        return Json(subscriptions);
    }

    [Route("users/{id}")]
    [HttpGet]
    public JsonResult GetUserSubscriptions(string id)
    {
        var subscriptions = subscriptionAuthorService.GetUserSubscriptions(id);
        return Json(subscriptions);
    }
    
    [Route("authors/{id}")]
    [HttpGet]
    public JsonResult GetAuthorSubscriptions(string id)
    {
        var subscriptions = subscriptionAuthorService.GetAuthorSubscriptions(id);
        return Json(subscriptions);
    }
    
    [Route("toggle")]
    [HttpPost]
    public async Task<IActionResult> ToggleActiveSubscriptions(ToggleSubscriptionAuthorDTO dto)
    {
        Task<IActionResult> result = subscriptionAuthorService.ToggleActiveSubscriptions(dto);
        return await result;
    }
}