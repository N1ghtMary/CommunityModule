using DTO.CommentDTO;
using Microsoft.AspNetCore.Mvc;

namespace Repository.CommentRepository;

public interface ICommentRepository
{
    CommentDTO Get(int id);
    List<CommentDTO> GetAll();
    Task<IActionResult> Insert(CreateCommentDTO dto);
    Task<IActionResult> Update(UpdateCommentDTO dto);
    void Delete(int id);
    void SaveChanges();
}