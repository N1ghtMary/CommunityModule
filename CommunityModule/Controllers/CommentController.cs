using DTO.CommentDTO;
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
    
    [Route("create")]
    [HttpPost]
    public JsonResult CreateComment(CreateCommentDTO dto)
    {
        commentService.InsertComment(dto);
        return Json("created");
    }
    
    [Route("update")]
    [HttpPatch]
    public JsonResult UpdateComment(UpdateCommentDTO dto)
    {
        commentService.UpdateComment(dto);
        return Json("updated");
    }
    
    [Route("delete/{id}")]
    [HttpDelete]
    public JsonResult DeleteComment(int id)
    {
        commentService.DeleteComment(id);
        return Json("deleted");
    }
}