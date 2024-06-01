using DTO.ArticleDTO;
using DTO.UserDTO;

namespace DTO.StatisticsDTO;

public class StatisticsDTO
{
    public int StatisticsId { get; set; }
    //public int ArticleId { get; set; }
    public bool IsLike { get; set; }
    //public string UserId { get; set; }
    public ShowUserInfoDTO User { get; set; }
    public ShowArticleInfoDTO Article { get; set; }
}