using DTO.CommentDTO;
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

    public void InsertComment(CreateCommentDTO dto)
    {
        _commentRepository.Insert(dto);
    }

    public void UpdateComment(UpdateCommentDTO dto)
    {
        _commentRepository.Update(dto);
    }

    public void DeleteComment(int Id)
    {
        _commentRepository.Delete(Id);
    }
}