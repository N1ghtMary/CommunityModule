using DTO.GroupDTO;
using DTO.UserDTO;

namespace DTO.ArticleDTO;

public class UpdateArticleDTO
{
    public int ArticleId { get; set; }
    public string Title { get; set; }
    public string ArticleText { get; set; }
    public DateTime ArticlePublicationDate { get; set; }
    //public int UserId { get; set; }
    //public int GroupId { get; set; }
    public EmailUserDTO User { get; set; }
    public ShowGroupInfoDTO Group { get; set; }
    public int Views { get; set; }
}