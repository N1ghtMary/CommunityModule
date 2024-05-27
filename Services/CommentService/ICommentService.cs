using DTO.CommentDTO;
using Microsoft.AspNetCore.Mvc;

namespace Services.CommentService;

public interface ICommentService
{
    CommentDTO GetComment(int Id);
    List<CommentDTO> GetComments();
    Task<IActionResult> InsertComment(CreateCommentDTO dto);
    Task<IActionResult> UpdateComment(UpdateCommentDTO dto);
    void DeleteComment(int Id);
}