using DTO.CommentDTO;

namespace Repository.CommentRepository;

public interface ICommentRepository
{
    CommentDTO Get(int Id);
    List<CommentDTO> GetAll();
    void Insert(CreateCommentDTO dto);
    void Update(UpdateCommentDTO dto);
    void Delete(int Id);
    void SaveChanges();
}