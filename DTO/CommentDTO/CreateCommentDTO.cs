using DTO.UserDTO;

namespace DTO.CommentDTO;

public class CreateCommentDTO
{
    public int CommentId { get; set; }
    public string CommentText { get; set; }
    //public DateTime CommentPublicationDate { get; set; }
    //public string UserId { get; set; }
    public EmailUserDTO User { get; set; }
    public int ArticleId { get; set; }
}