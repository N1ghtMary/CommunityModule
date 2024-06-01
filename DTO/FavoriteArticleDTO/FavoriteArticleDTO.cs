using DTO.ArticleDTO;
using DTO.UserDTO;

namespace DTO.FavoriteArticleDTO;

public class FavoriteArticleDTO
{
    public int FavoriteId { get; set; }
    public ShowArticleInfoDTO Article { get; set; }
    //public string UserId { get; set; }
    public ShowUserInfoDTO User { get; set; }
}