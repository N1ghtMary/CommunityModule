using DTO.CommentDTO;

namespace Services.CommentService;

public interface ICommentService
{
    CommentDTO GetComment(int Id);
    List<CommentDTO> GetComments();
    void InsertComment(CreateCommentDTO dto);
    void UpdateComment(UpdateCommentDTO dto);
    void DeleteComment(int Id);
}