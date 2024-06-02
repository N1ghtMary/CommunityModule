using DTO.CommentDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.CommentService;

namespace CommunityModule.Controllers;

[ApiController]
[Route("comments")]
public class CommentController(ICommentService commentService):Controller
{
    [Route("{id}")]
    [HttpGet]
    public JsonResult GetComment(int id)
    {
        var comment = commentService.GetComment(id);
        return Json(comment);
    }
    
    [HttpGet]
    public JsonResult GetComments()
    {
        var comments = commentService.GetComments();
        return Json(comments);
    }
    
    [Authorize]
    [Route("create")]
    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentDTO dto)
    {
        Task<IActionResult> result = commentService.InsertComment(dto);
        return await result;
    }
    
    [Authorize]
    [Route("update")]
    [HttpPatch]
    public async Task<IActionResult> UpdateComment(UpdateCommentDTO dto)
    {
        Task<IActionResult> result = commentService.UpdateComment(dto);
        return await result;
    }
    
    [Authorize]
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteComment(int id)
    {
        commentService.DeleteComment(id);
        return Json("deleted");
    }
}