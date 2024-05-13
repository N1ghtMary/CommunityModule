using DTO.SubscriptionAuthorDTO;
using Microsoft.AspNetCore.Mvc;
using Services.SubscriptionAuthorService;

namespace CommunityModule.Controllers;

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
    public JsonResult GetUserSubscriptions(int id)
    {
        var subscriptions = subscriptionAuthorService.GetUserSubscriptions(id);
        return Json(subscriptions);
    }
    
    [Route("authors/{id}")]
    [HttpGet]
    public JsonResult GetAuthorSubscriptions(int id)
    {
        var subscriptions = subscriptionAuthorService.GetAuthorSubscriptions(id);
        return Json(subscriptions);
    }
    
    [Route("toggle")]
    [HttpPost]
    public JsonResult ToggleActiveSubscriptions(ToggleSubscriptionAuthorDTO dto)
    {
        subscriptionAuthorService.ToggleActiveSubscriptions(dto);
        return Json("completed");
    }
}