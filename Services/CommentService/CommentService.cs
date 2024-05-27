using DTO.CommentDTO;
using Microsoft.AspNetCore.Mvc;
using Repository.CommentRepository;

namespace Services.CommentService;

public class CommentService(ICommentRepository commentRepository) : ICommentService
{
    private ICommentRepository _commentRepository = commentRepository;

    public CommentDTO GetComment(int Id)
    {
        return _commentRepository.Get(Id);
    }

    public List<CommentDTO> GetComments()
    {
        return _commentRepository.GetAll();
    }

    public async Task<IActionResult> InsertComment(CreateCommentDTO dto)
    {
        return await _commentRepository.Insert(dto);
    }

    public async Task<IActionResult> UpdateComment(UpdateCommentDTO dto)
    {
        return await _commentRepository.Update(dto);
    }

    public void DeleteComment(int id)
    {
        _commentRepository.Delete(id);
    }
}