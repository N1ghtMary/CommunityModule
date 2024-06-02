using DTO.FavoriteArticleDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.FavoriteArticleService;

namespace CommunityModule.Controllers;

[Authorize]
[ApiController]
[Route("favoritearticles")]
public class FavoriteArticleController(IFavoriteArticleService favoriteArticleService):Controller
{
    [HttpGet]
    public JsonResult GetFavoriteArticles()
    {
        var favoriteArticles = favoriteArticleService.GetFavoriteArticles();
        return Json(favoriteArticles);
    }

    [Route("{id}")]
    [HttpGet]
    public JsonResult GetUserFavoriteArticles(string id)
    {
        var favoriteArticlesUser = favoriteArticleService.GetUserFavoriteArticles(id);
        return Json(favoriteArticlesUser);
    }

    [Route("create")]
    [HttpPost]
    public async Task<IActionResult> InsertFavoriteArticle(CreateFavoriteArticleDTO dto)
    {
        Task<IActionResult> result = favoriteArticleService.InsertFavoriteArticle(dto);
        return await result;
    }

    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteFavoriteArticle(int id)
    {
        favoriteArticleService.DeleteFavoriteArticle(id);
        return Json("deleted");
    }
}