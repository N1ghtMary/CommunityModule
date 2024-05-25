using DTO.ArticleDTO;
using Microsoft.AspNetCore.Http.HttpResults;
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
        if (article == null) return Json("Invalid article");
        return Json(article);
    }
    
    [HttpGet]
    public JsonResult GetArticles()
    {
        var articles = articleService.GetArticles();
        if (articles == null) return Json("Empty list");
        return Json(articles);
    }
    
    [Route("create")]
    [HttpPost]
    public async Task<IActionResult> CreateArticle(CreateArticleDTO dto)
    {
       Task<IActionResult> result=  articleService.InsertArticle(dto);
        //if (result is BadRequestObjectResult) return (BadRequest)result.ToString();
        return await result;
    }
    
    [Route("update")]
    [HttpPatch]
    public async Task<IActionResult> UpdateArticle(UpdateArticleDTO dto)
    {
        Task<IActionResult> result = articleService.UpdateArticle(dto);
        return await result;
    }

    [Route("increaseViews/{id}")]
    [HttpPatch]
    public async Task<IActionResult> IncreaseViewArticle(int id)
    {
        //if (id == null) return Json("Invalid id");
        Task<IActionResult> result = articleService.IncreaseViewsArticle(id);
        return await result;
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        Task<IActionResult> result = articleService.DeleteArticle(id);
        return await result;
    }
}