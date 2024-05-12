using DTO.StatisticsDTO;
using Microsoft.AspNetCore.Mvc;
using Services.StatisticsService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("statistics")]
public class StatisticsController(IStatisticsService statisticsService):Controller
{
    [HttpGet]
    public JsonResult GetStatistics()
    {
        var statistics = statisticsService.GetStatistics();
        return Json(statistics);
    }
    
    [Route("users/{id}")]
    [HttpGet]
    public JsonResult GetUserStatistics(int id)
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

    [Route("toggle")]
    [HttpPost]
    public JsonResult ToggleLikeStatistics(ToggleStatisticsDTO dto)
    {
        statisticsService.ToggleLikeStatistics(dto);
        return Json("completed");
    }
}