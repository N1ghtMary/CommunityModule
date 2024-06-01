using DTO.ArticleDTO;
using DTO.UserDTO;

namespace DTO.CommentDTO;

public class CommentDTO
{
    public int CommentId { get; set; }
    public string CommentText { get; set; }
    public DateTime CommentPublicationDate { get; set; }
    //public string UserId { get; set; }
    public ShowUserInfoDTO User { get; set; }
    public ShowArticleInfoDTO Article { get; set; }
}