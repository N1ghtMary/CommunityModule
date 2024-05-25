using Data;
using DTO.GroupDTO;
using DTO.UserDTO;

namespace DTO.ArticleDTO;

public class ArticleDTO
{
    public int ArticleId { get; set; }
    public string Title { get; set; }
    public string ArticleText { get; set; }
    public DateTime ArticlePublicationDate { get; set; }
    public ShowUserInfoDTO User { get; set; }
    public ShowGroupInfoDTO Group { get; set; }
    public int Views { get; set; }
}