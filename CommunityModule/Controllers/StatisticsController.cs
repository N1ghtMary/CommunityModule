using DTO.StatisticsDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.StatisticsService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("statistics")]
public class StatisticsController(IStatisticsService statisticsService):Controller
{
    [Authorize]
    [HttpGet]
    public JsonResult GetStatistics()
    {
        var statistics = statisticsService.GetStatistics();
        return Json(statistics);
    }
    
    [Authorize]
    [Route("users/{id}")]
    [HttpGet]
    public JsonResult GetUserStatistics(string id)
    {
        var statistics = statisticsService.GetUserStatistics(id);
        return Json(statistics);
    }
    
    [Route("articles/{id}")]
    [HttpGet]
    public JsonResult GetArticleStatistics(int id)
    {
        var statistics = statisticsService.GetArticleStatistics(id);
        return Json(statistics);
    }

    [Authorize]
    [Route("like")]
    [HttpPatch]
    public async Task<IActionResult> LikeStatistics(ToggleStatisticsDTO dto)
    {
        Task<IActionResult> result = statisticsService.LikeArticle(dto);
        return await result;
    }
    
    [Authorize]
    [Route("dislike")]
    [HttpPatch]
    public async Task<IActionResult> DislikeStatistics(ToggleStatisticsDTO dto)
    {
        Task<IActionResult> result = statisticsService.DislikeArticle(dto);
        return await result;
    }

    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteStatistics(int id)
    {
        statisticsService.DeleteStatistics(id);
        return Json("deleted");
    }
}