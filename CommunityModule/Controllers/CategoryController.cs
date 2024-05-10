using DTO.CategoryDTO;
using Microsoft.AspNetCore.Mvc;
using Services.CategoryService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("categories")]
public class CategoryController(ICategoryService categoryService):Controller
{
    [Route("{id}")]
    [HttpGet]
    public JsonResult GetCategory(int id)
    {
        var category = categoryService.GetCategory(id);
        //if (category == null) return NotFound("Category not found");
        return Json(category);
    }
    
    [HttpGet]
    public JsonResult GetCategories()
    {
        var categories = categoryService.GetCategories();
        return Json(categories);
    }
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateCategory(CreateCategoryDTO dto)
    {
        categoryService.InsertCategory(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateCategory(UpdateCategoryDTO dto)
    {
        categoryService.UpdateCategory(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteCategory(int id)
    {
        categoryService.DeleteCategory(id);
        return Json("deleted");
    }
}