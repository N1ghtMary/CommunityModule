using DTO.ArticleDTO;
using Microsoft.AspNetCore.Mvc;
using Services.ArticleService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("articles")]
public class ArticleController(IArticleService articleService):Controller
{
    [Route("{id}")]
    [HttpGet]
    public JsonResult GetArticle(int id)
    {
        var article = articleService.GetArticle(id);
        return Json(article);
    }
    
    [HttpGet]
    public JsonResult GetArticles()
    {
        var articles = articleService.GetArticles();
        return Json(articles);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateArticle(CreateArticleDTO dto)
    {
        articleService.InsertArticle(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateArticle(UpdateArticleDTO dto)
    {
        articleService.UpdateArticle(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteArticle(int id)
    {
        articleService.DeleteArticle(id);
        return Json("deleted");
    }
}