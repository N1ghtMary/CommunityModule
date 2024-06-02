using DTO.CategoryDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.CategoryService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("categories")]
public class CategoryController(ICategoryService categoryService):Controller
{
    [Authorize]
    [Route("{id}")]
    [HttpGet]
    public JsonResult GetCategory(int id)
    {
        var category = categoryService.GetCategory(id);
        //if (category == null) return NotFound("Category not found");
        return Json(category);
    }
    
    [Authorize]
    [HttpGet]
    public JsonResult GetCategories()
    {
        var categories = categoryService.GetCategories();
        return Json(categories);
    }
    
    [Authorize]
    [Route("create")]
    [HttpPost]
    public JsonResult CreateCategory(CreateCategoryDTO dto)
    {
        categoryService.InsertCategory(dto);
        return Json("created");
    }
    
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateCategory(UpdateCategoryDTO dto)
    {
        categoryService.UpdateCategory(dto);
        return Json("updated");
    }
    
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteCategory(int id)
    {
        categoryService.DeleteCategory(id);
        return Json("deleted");
    }
}