using DTO.FavoriteArticleDTO;
using Microsoft.AspNetCore.Mvc;
using Services.FavoriteArticleService;

namespace CommunityModule.Controllers;

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
    public JsonResult GetUserFavoriteArticles(int id)
    {
        var favoriteArticlesUser = favoriteArticleService.GetUserFavoriteArticles(id);
        return Json(favoriteArticlesUser);
    }

    [Route("create")]
    [HttpPost]
    public JsonResult InsertFavoriteArticle(CreateFavoriteArticleDTO dto)
    {
        favoriteArticleService.InsertFavoriteArticle(dto);
        return Json("created");
    }

    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteFavoriteArticle(int id)
    {
        favoriteArticleService.DeleteFavoriteArticle(id);
        return Json("deleted");
    }
}